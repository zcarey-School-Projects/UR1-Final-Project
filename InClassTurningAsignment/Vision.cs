using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using Emgu.CV.Util;
using System.Diagnostics;

namespace InClassTurningAsignment
{
    public class Vision
    {

        private Form1 UI;
        private Robot robot;
        private Thread captureThread;

        private static float BASE_YELLOW = 42.5f;

        //Variables
        private float saturationThreshold;
        private float valueThreshold;
        private float angleThreshold;
        private float thresholdSeperationPercent;
        private float lowSqrHue;
        private float highSqrHue;
        private float lowSqrSat;
        private float highSqrSat;
        private float lowSqrVal;
        private float highSqrVal;
        private Line rightThreshLine;
        private Line leftThreshLine;
        private Line centerLine;
        private Line yThreshLine;
        private Line bestFitLine;
        private float yThreshPercent;
        private bool equalizeHist = false;
        private bool erode = false;
        private bool dialate = false;
        private float minLineLength = 50f;

        private bool redrawROI = true;
        private float roiSeparation = 0;
        private float roiAngle = 0;
        private float roiYThresh = 0;
        private Image<Gray, byte> roi = null;
        private Image<Gray, byte> roiLeft = null;
        private Image<Gray, byte> roiRight = null;

        double maxLineGap = 200;
        private static float runSpeed = 0.7f;

        private InputHandler input;

        private bool turnUntilPass = false;
        private bool wasAbove = false;
        private bool wasVertical = false;

        public Vision(Form1 UI, Robot robot, int cameraIndex)
        {
            this.UI = UI;
            this.robot = robot;
            //Image<Gray, float> sobel = gray.Sobel(0, 1, 3).Add(gray.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
            centerLine = Line.getVerticalLine(0);
            centerLine.setLineColor(Options.CenterLineColor);
            centerLine.setLineThickness(Options.CenterLineThickness);

            yThreshLine = Line.getHorizontalLine(0);
            yThreshLine.setLineColor(Options.YThresholdLineColor);
            yThreshLine.setLineThickness(Options.YThresholdLineThickness);

            leftThreshLine = new Line();
            leftThreshLine.setLineColor(Options.ThresholdLineColor);
            leftThreshLine.setLineThickness(Options.ThresholdLineThickness);

            rightThreshLine = new Line();
            rightThreshLine.setLineColor(Options.ThresholdLineColor);
            rightThreshLine.setLineThickness(Options.ThresholdLineThickness);

            bestFitLine = new Line();
            bestFitLine.setLineColor(Options.BestFitColor);
            bestFitLine.setLineThickness(Options.BestFitThickness);

            //capture = new VideoCapture(cameraIndex);
            captureThread = new Thread(VisionThread);

            input = new InputHandler();
            /*bool found = input.setImage("VideoFiles\\s1");
            if (!found)
            {
                throw new ArgumentNullException("File could not be loaded!");
            }
            input.play();*/
            //setImage("VideoFiles\\s4");
            input.setCamera(1);
            input.play();
        }

        private void VisionThread()
        {

            Image<Bgr, byte> origImage;
            Image<Hsv, byte> hsvImage;
            Image<Gray, byte> threshImage;
            Image<Gray, byte> redImage;
            Image<Bgr, byte> maskedImage;
            DateTime lastTime = DateTime.UtcNow;
            float[] FPS_times = new float[Options.FPS_NumFramesToAvg];
            float totalFPS = 0;
            int FPS_index = 0;
            List<Line> slopeAvg = new List<Line>();
            Stopwatch timer = new Stopwatch();
            bool turning = false;

            robot.setSpeed(runSpeed);

            while (true)
            {
                origImage = input.readFrame();
                if (origImage == null)
                {
                    Thread.Sleep(1);
                    continue;
                }

                //Determine the native resolution of the image and display to user.
                String nativeSize = "Native Resolution: " + origImage.Width + " x " + origImage.Height;
                UI.Invoke(new Action(() => UI.setResolutionText(nativeSize)));
                if (equalizeHist)
                {
                    origImage._EqualizeHist();
                }
                origImage = origImage.Resize(640, 480, Emgu.CV.CvEnum.Inter.Cubic);

                if (redrawROI || (roiLeft == null) || (roiRight == null) || !origImage.Size.Equals(roiLeft) || !origImage.Size.Equals(roiRight))
                {
                    roiLeft = new Image<Gray, byte>(origImage.Size);
                    roiRight = new Image<Gray, byte>(origImage.Size);

                    Point[] pointsLeft = new Point[4];
                    Point[] pointsRight = new Point[4];
                    int y = (int)(origImage.Height * yThreshPercent / 100f);
                    Rectangle bounds = new Rectangle(0, y, origImage.Width, origImage.Height - y);
                    float seperation = origImage.Width * (thresholdSeperationPercent / 100f);
                    leftThreshLine.setIntercept(new PointF(origImage.Width / 2f - seperation, origImage.Height - 1));
                    rightThreshLine.setIntercept(new PointF(origImage.Width / 2f + seperation, origImage.Height - 1));

                    pointsLeft[0] = new Point(origImage.Width / 2, origImage.Height - 1);
                    PointF p1 = (PointF)leftThreshLine.getPointAtY(origImage.Height - 1);
                    pointsLeft[1] = new Point((int) p1.X, (int) p1.Y);
                    PointF p2 = (PointF)leftThreshLine.getPointAtY(y);
                    pointsLeft[2] = new Point((int) p2.X, (int) p2.Y);
                    pointsLeft[3] = new Point(origImage.Width / 2, y);

                    pointsRight[0] = new Point(origImage.Width / 2 + 1, origImage.Height - 1);
                    p1 = (PointF)rightThreshLine.getPointAtY(origImage.Height - 1);
                    pointsRight[1] = new Point((int) p1.X, (int) p1.Y);
                    p2 = (PointF)rightThreshLine.getPointAtY(y);
                    pointsRight[2] = new Point((int) p2.X, (int) p2.Y);
                    pointsRight[3] = new Point(origImage.Width / 2 + 1, y);

                    roiLeft.FillConvexPoly(pointsLeft, new Gray(255));
                    roiRight.FillConvexPoly(pointsRight, new Gray(255));
                    //roi = roiLeft | roiRight;

                    roi = new Image<Gray, byte>(origImage.Width, origImage.Height, new Gray(255));
                }

                hsvImage = origImage.Convert<Hsv, byte>();

                //Threshold Square Hue
                if (lowSqrHue > highSqrHue)
                {
                    redImage = hsvImage[0].ThresholdBinary(new Gray(lowSqrHue), new Gray(255));
                    redImage |= hsvImage[0].ThresholdBinaryInv(new Gray(highSqrHue), new Gray(255));
                }
                else
                {
                    redImage = hsvImage[0].ThresholdBinary(new Gray(lowSqrHue), new Gray(255));
                    redImage &= hsvImage[0].ThresholdBinaryInv(new Gray(highSqrHue), new Gray(255));
                }

                //Threshold Square sat / val
                redImage &= hsvImage[1].ThresholdBinary(new Gray(lowSqrSat), new Gray(255));
                redImage &= hsvImage[1].ThresholdBinaryInv(new Gray(highSqrSat), new Gray(255));

                redImage &= hsvImage[2].ThresholdBinary(new Gray(lowSqrVal), new Gray(255));
                redImage &= hsvImage[2].ThresholdBinaryInv(new Gray(highSqrVal), new Gray(255));

                //Threshold saturation
                threshImage = origImage[1].ThresholdBinary(new Gray(saturationThreshold), new Gray(255));

                //Threshold value then bitwise & with other threshold value
                threshImage &= origImage[2].ThresholdBinary(new Gray(valueThreshold), new Gray(255));

                //Dialte and erode thresh image to remove noise.
                if (dialate)
                {
                    threshImage._Dilate(3);
                    threshImage._Erode(3);

                    redImage._Dilate(3);
                    redImage._Erode(3);
                }

                if (erode)
                {
                    threshImage._Erode(3);
                    threshImage._Dilate(3);

                    redImage._Erode(3);
                    redImage._Dilate(3);
                }

                threshImage = threshImage.SmoothGaussian(5);
                redImage = redImage.SmoothGaussian(5);

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(redImage, contours, null, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                Rectangle? redSquare = null;

                int contCount = contours.Size;
                if(contCount == 0)
                {
                    //None found!
                }else
                {
                    int leftBounds = origImage.Width;
                    int rightBounds = 0;
                    int upperBounds = origImage.Height;
                    int lowerBounds = 0;

                    for (int i = 0; i < contCount; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        {
                            Rectangle box = CvInvoke.BoundingRectangle(contour);
                            if (box.X < leftBounds)
                                leftBounds = box.X;
                            if (box.Y < upperBounds)
                                upperBounds = box.Y;
                            if (box.X + box.Width > rightBounds)
                                rightBounds = box.X + box.Width;
                            if (box.Y + box.Height > lowerBounds)
                                lowerBounds = box.Y + box.Height;

                            //origImage.Draw(CvInvoke.BoundingRectangle(contour), new Bgr(255, 0, 0), 4);
                            //segmentRectangles.Add(CvInvoke.BoundingRectangle(contour));
                        }
                    }
                    redSquare = new Rectangle(leftBounds, upperBounds, rightBounds - leftBounds, lowerBounds - upperBounds);
                    origImage.Draw((Rectangle)redSquare, new Bgr(255, 0, 0), 4);
                }
                

                Image<Gray, byte> canny = threshImage.Canny(50, 150);
                maskedImage = canny.Convert<Bgr, byte>();

                //rho and theta are the distance and angular resolution of the grid in Hough space

                double rho = 2;
                double theta = Math.PI / 180;
                //threshold is minimum number of intersections in a grid for candidate line to go to output
                int threshold = 20;

                LineSegment2D[][] houghLines = (threshImage & roi).HoughLines(50, 150, rho, theta, threshold, minLineLength, maxLineGap);
                List<Line> lines = new List<Line>();

                foreach(LineSegment2D[] segment in houghLines)
                {
                    foreach(LineSegment2D seg in segment)
                    {
                        Line line = new Line(seg.P1, seg.P2);
                        //if (Math.Abs(line.slope) < 0.57735026918963)
                        //    continue;
                        lines.Add(line);
                        line.setLineColor(new Bgr(0, 0, 255));
                        //line.drawLine(origImage);
                        CvInvoke.Line(origImage, seg.P1, seg.P2, new Bgra(0, 0, 255, 191.25f).MCvScalar, 2);
                    }
                }

                Line avgLine = Line.averageLines(lines);
                if (avgLine != null)
                {
                    if (slopeAvg.Count == 5)
                        slopeAvg.RemoveAt(0);
                    slopeAvg.Add(avgLine);
                }

                avgLine = Line.averageLines(slopeAvg);
                if (avgLine != null)
                {

                    avgLine.setLineThickness(10);
                    avgLine.setLineColor(new Bgr(0, 255, 255));
                    avgLine.drawLine(origImage);
                }
                //Determine Y thresh
                int yThresh = (int)(maskedImage.Height * yThreshPercent / 100f);

                //Draw threshold lines
                Rectangle threshBounds = new Rectangle(0, yThresh, maskedImage.Width, maskedImage.Height - yThresh);
                float thresholdSeperation = maskedImage.Width * (thresholdSeperationPercent / 100f);
                leftThreshLine.setIntercept(new PointF(maskedImage.Width / 2f - thresholdSeperation, maskedImage.Height - 1));
                rightThreshLine.setIntercept(new PointF(maskedImage.Width / 2f + thresholdSeperation, maskedImage.Height - 1));

                leftThreshLine.drawLine(origImage, threshBounds);
                rightThreshLine.drawLine(origImage, threshBounds);
                
                //Draw Y thresh line and center line
                centerLine.setIntercept(new PointF(maskedImage.Width / 2, 0));
                centerLine.drawLine(origImage, threshBounds);
                yThreshLine.setIntercept(new PointF(maskedImage.Width / 2, yThresh));
                PointF left = (PointF)leftThreshLine.getPointAtY(yThresh);
                PointF right = (PointF)rightThreshLine.getPointAtY(yThresh);
                threshBounds = new Rectangle((int)left.X, 0, (int)(right.X - left.X), origImage.Height);
                yThreshLine.drawLine(origImage, threshBounds);

                if (avgLine != null)
                {
                /*    PointF? centerHittest = avgLine.getPointAtX(origImage.Width / 2);
                    if (centerHittest != null)
                    {
                        PointF hit = (PointF)centerHittest;
                        CvInvoke.Line(origImage, new Point(0, (int)hit.Y), new Point(origImage.Width, (int) hit.Y), new Bgr(255, 0, 0).MCvScalar, 3);
                    }
                    */
                    //Check if the line passes through either thresh line
                    Rectangle region = new Rectangle(0, yThresh, origImage.Width, origImage.Height - yThresh);
                    bool passesLeftThresh = leftThreshLine.intersects(avgLine, region);
                    bool passesRightThresh = rightThreshLine.intersects(avgLine, region);
                    bool passesCenter = centerLine.intersects(avgLine, region);
                    Console.WriteLine(passesLeftThresh + " " + passesCenter + " " + passesRightThresh);
                    Robot.Command command = Robot.Command.Forward;

                    if (turning)
                    {
                        command = Robot.Command.SpinLeft;
                        if (timer.ElapsedMilliseconds > 1850) //2400
                        {
                            timer.Stop();
                            robot.setSpeed(runSpeed);
                            command = Robot.Command.Forward;
                            turning = false;
                        }
                    } else {
                        bool isSquare = false;
                        if(redSquare != null)
                        {
                            Rectangle rs = (Rectangle)redSquare;
                            if (rs.Y + rs.Height > origImage.Height / 4)
                            {
                                isSquare = true;
                            }
                        }

                        if (isSquare)
                        {
                            turning = true;
                            robot.setSpeed(1);
                            command = Robot.Command.SpinLeft;
                            timer.Restart();
                        }
                        else if (turnUntilPass)
                        {
                            command = robot.getLastCommand(); //Keep turning!

                            PointF? centerHit = avgLine.getPointAtX(origImage.Width / 2);
                            if (centerHit != null)
                            {
                                PointF hit = (PointF)centerHit;
                                if (wasVertical && hit.Y < origImage.Height && hit.Y > yThresh)
                                {
                                    turnUntilPass = false;
                                    command = Robot.Command.Forward;
                                }
                                else if (!wasVertical)
                                {
                                    if (wasAbove && hit.Y > origImage.Height / 2)
                                    {
                                        turnUntilPass = false;
                                        command = Robot.Command.Forward;
                                    } else if (!wasAbove && hit.Y < origImage.Height / 2)
                                    {
                                        turnUntilPass = false;
                                        command = Robot.Command.Forward;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (/*!passesCenter && */ (passesLeftThresh || passesRightThresh))
                            {
                                command = (passesLeftThresh ? Robot.Command.Left : Robot.Command.Right);

                                turnUntilPass = true;
                                PointF? centerHit = avgLine.getPointAtX(origImage.Width / 2);
                                if (centerHit != null)
                                {
                                    wasVertical = false;
                                    PointF hit = (PointF)centerHit;
                                    wasAbove = (hit.Y < origImage.Height / 2);
                                } else
                                {
                                    wasVertical = true;
                                }
                            }
                            else
                            {
                                PointF? posE = avgLine.getPointAtY(origImage.Height / 2);
                                if (posE != null)
                                {
                                    PointF pos = (PointF)posE;

                                }
                            }
                        }
                    }

                    robot.sendVisionCommand(command);
                }

                //Calculate FPS and write to text.
                DateTime currentTime = DateTime.UtcNow;
                TimeSpan span = currentTime.Subtract(lastTime);
                float currentFPS = 1000f / (float)span.TotalMilliseconds;
                lastTime = currentTime;
                totalFPS -= FPS_times[FPS_index];
                totalFPS += currentFPS;
                FPS_times[FPS_index] = currentFPS;
                FPS_index++;
                if (FPS_index >= Options.FPS_NumFramesToAvg)
                {
                    FPS_index = 0;
                }
                float FPS = totalFPS / Options.FPS_NumFramesToAvg;

                //String FPSText = FPS.ToString();
                // CvInvoke.PutText(origImage, FPSText, Options.FPS_Position, Options.FPS_Font, Options.FPS_FontScale, Options.FPS_TextColor.MCvScalar);
                UI.Invoke(new Action(() => UI.setFPS(FPS)));
                //Display images to screen.
                UI.displayImage(ref origImage, Form1.PictureId.Original);
                UI.displayImage(ref threshImage, Form1.PictureId.Threshold);
                UI.displayImage(ref maskedImage, Form1.PictureId.Masked);
                UI.displayImage(ref redImage, Form1.PictureId.Red);
            }
        }

        public void start()
        {
            captureThread.Start();
        }

        public void stop()
        {
            captureThread.Abort();
        }

        public void play()
        {
            input.play();
        }

        public void pause()
        {
            input.pause();
        }

        public bool setCamera(int cameraId)
        {
            input.setCamera(cameraId);
            return input.isFrameAvailable();
        }

        public bool setVideo(String filename)
        {
            return input.setVideo(filename);
        }

        public bool setImage(String filename)
        {
            return input.setImage(filename);
        }

        public bool loadImage()
        {
            return input.requestLoadImage();
        }

        public bool loadVideo()
        {
            return input.requestLoadVideo();
        }

        public bool loadInput()
        {
            return input.requestLoadInput();
        }

        public Line getLeftLine()
        {
            return new Line(leftThreshLine);
        }

        public Line getRightLine()
        {
            return new InClassTurningAsignment.Line(rightThreshLine);
        }

        public void setROISeparation(float sep)
        {
            this.roiSeparation = sep;
            redrawROI = true;
        }

        public void setROIAngle(float ang)
        {
            this.roiAngle = ang;
            redrawROI = true;
        }

        public void setROIYThresh(float y)
        {
            this.roiYThresh = y;
            redrawROI = true;
        }

        public void setVariable(Variable target, bool val)
        {
            switch (target)
            {
                case Variable.EqualizeHistogram:
                    equalizeHist = val;
                    break;
                case Variable.Erode:
                    erode = val;
                    break;
                case Variable.Dialate:
                    dialate = val;
                    break;
            }
        }

        public void setVariable(Variable target, float val)
        {
            switch (target)
            {
                case Variable.LowSquareHue:
                    lowSqrHue = val;
                    break;
                case Variable.HighSquareHue:
                    highSqrHue = val;
                    break;
                case Variable.LowSquareSaturation:
                    lowSqrSat = val;
                    break;
                case Variable.HighSquareSaturation:
                    highSqrSat = val;
                    break;
                case Variable.LowSquareValue:
                    lowSqrVal = val;
                    break;
                case Variable.HighSquareValue:
                    highSqrVal = val;
                    break;
                case Variable.SaturationThreshold:
                    saturationThreshold = val;
                    break;
                case Variable.ValueThreshold:
                    valueThreshold = val;
                    break;
                case Variable.AngleThreshold:
                    angleThreshold = (float) (Math.PI * val / 180f);
                    //NOTE 0, 0 is in the top left so the lines may seem backwards, but are not
                    rightThreshLine.setLine(Line.getLineFromAngle(Math.PI / 2 + angleThreshold));
                    leftThreshLine.setLine(Line.getLineFromAngle(Math.PI / 2 - angleThreshold));
                    break;
                case Variable.ThresholdSeparationPercent:
                    thresholdSeperationPercent = val;
                    break;
                case Variable.YThresholdPercent:
                    yThreshPercent = val;
                    break;
                case Variable.MaxLineGap:
                    maxLineGap = val;
                    break;
                case Variable.MinLineLength:
                    minLineLength = val;
                    break;
            }
        }

        public enum Variable
        {
            LowSquareHue,
            HighSquareHue,
            LowSquareSaturation,
            HighSquareSaturation,
            LowSquareValue,
            HighSquareValue,
            SaturationThreshold,
            ValueThreshold,
            AngleThreshold,
            ThresholdSeparationPercent,
            YThresholdPercent,
            EqualizeHistogram,
            Erode,
            Dialate,
            MaxLineGap,
            MinLineLength
        }

    }

}
