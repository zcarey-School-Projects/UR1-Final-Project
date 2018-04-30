using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace InClassTurningAsignment
{
    public class Line
    {
        private double slope;
        private double offset; //If line is vertical, is X offset. Otherwise, Y offset.
        public bool isVertical = false;

        //Drawing variables
        Bgr lineColor = new Bgr(0, 0, 0);
        int lineThickness = 1;

        public Line()
        {
            slope = 0;
            offset = 0;
        }

        public Line(double slope, double offset)
        {
            this.slope = 1 / slope;
            this.offset = -offset / slope; //Part of the flipping process

            if (double.IsNaN(slope))
            {
                isVertical = true;
            }
        }

        public Line(PointF p1, PointF p2)
        {
            slope = (p1.X - p2.X) / (p1.Y - p2.Y);

            if (double.IsNaN(slope))
            {
                isVertical = true;
            }
            setIntercept(p1);
        }

        public Line(Line copy)
        {
            this.slope = copy.slope;
            this.offset = copy.offset;
            this.isVertical = copy.isVertical;
            this.lineColor = copy.lineColor;
            this.lineThickness = copy.lineThickness;
        }

        public double getSlope()
        {
            return 1 / slope;
        }

        public PointF? getPointAtY(double y) //Secretly get point at x
        {
            if (isVertical)
            {
                return null;
            }else {
                return new PointF((float) (slope * y + offset), (float) y); //Flip back
            }
        }

        public PointF? getPointAtX(double x) //Secretly get point at y
        {
            if (slope == 0)
            {
                return null;
            }

            return new PointF((float) x, (float)((x - offset) / slope));
        }

        //Adjusts the graph's offset to pass through the given point
        public void setIntercept(PointF p)
        {
            if (isVertical)
            {
                offset = p.Y; //Remember, flipped!
            }else
            {
                offset = p.X - slope * p.Y; //FLIPPED
            }
        }

        //Checks if the two lines intersect anywhere in the given region
        public bool intersects(Line line, Rectangle region)
        {
            if(isVertical && line.isVertical)
            {
                //If both lines are vertical, check for similar offsets (highly unlikely)
                return offset == line.offset;
            }else if(isVertical || line.isVertical)
            {
                //If only one line is vertical, check if intersection is in the region
                double y = (line.slope * offset) + line.offset;
                return y > region.Y && y < (region.Y + region.Height);
            }else
            {
                //Find x value of intersection
                double x = (line.offset - offset) / (slope - line.slope);
                //Check if it is within bounding box.
                double y = (slope * x) + offset;
                return y >= region.X && y <= (region.X + region.Width) && x >= region.Y && x <= (region.Y + region.Height); //Remember, flipped!
            }
        }

        private LineSegment2DF? getDrawnLine(Rectangle bounds)
        {
            int eastBound = bounds.X + bounds.Width;
            int southBound = bounds.Y + bounds.Height;

            PointF? topPoint = getPointAtY(bounds.Y);
            PointF? bottomPoint = null;
            bool topFound = false;
            bool botFound = false;

            if (isVertical)
            {
                PointF p1 = new PointF(bounds.X, (float)offset);
                PointF p2 = new PointF(eastBound, (float)offset);
                return new LineSegment2DF(p1, p2);
            }
            else
            {

                if (topPoint != null)
                {
                    PointF tp = (PointF)topPoint;
                    topFound = (tp.X >= bounds.X && tp.X <= eastBound);
                }

                if (!topFound)
                {
                    //Line does not pass through north bound, next test the west bound;
                    topPoint = getPointAtX(bounds.X);
                    if (topPoint != null)
                    {
                        PointF tp = (PointF)topPoint;
                        topFound = (tp.Y >= bounds.Y && tp.Y <= southBound);
                    }
                    if (!topFound)
                    {
                        //Not west bound, there must be a point at the east bound.
                        topPoint = getPointAtX(eastBound);
                        //That also means the other point has to be on the south bound.
                        bottomPoint = getPointAtY(southBound);
                    }
                    else
                    {
                        //North point is at west bound, look for other point at either east or south
                        //First test east.
                        bottomPoint = getPointAtX(eastBound);
                        if (bottomPoint != null)
                        {
                            PointF bp = (PointF)bottomPoint;
                            botFound = (bp.Y >= bounds.Y && bp.Y <= southBound);
                        }
                        if (!botFound)
                        {
                            //Not east, must be south.
                            bottomPoint = getPointAtY(southBound);
                        }
                    }
                }
                else
                {
                    //Top point is on the north bounds, look for other at west bound
                    bottomPoint = getPointAtX(bounds.X);
                    if (bottomPoint != null)
                    {
                        PointF bp = (PointF)bottomPoint;
                        botFound = (bp.Y >= bounds.Y && bp.Y <= southBound);
                    }
                    if (!botFound)
                    {
                        //Not west bound, look at east bound.
                        bottomPoint = getPointAtX(eastBound);
                        if (bottomPoint != null)
                        {
                            PointF bp = (PointF)bottomPoint;
                            botFound = (bp.Y >= bounds.Y && bp.Y <= southBound);
                        }
                        if (!botFound)
                        {
                            //Not east bound, must be at south bound.
                            bottomPoint = getPointAtY(southBound);
                        }
                    }
                }
            }

            if (topPoint == null || bottomPoint == null)
            {
                return null; //Oh well. We tried but we cant do it.
            }


            return new LineSegment2DF((PointF)topPoint, (PointF)bottomPoint);
        }

        public void drawLine(Image<Bgr, byte> image, Rectangle bounds)
        {
            LineSegment2DF? testLine = getDrawnLine(bounds);
            if(testLine != null)
            {
                LineSegment2DF line = (LineSegment2DF)testLine;
                image.Draw(line, lineColor, lineThickness);
            }
        }

        public void drawLine(Image<Gray, byte> image, Rectangle bounds)
        {
            LineSegment2DF? testLine = getDrawnLine(bounds);
            if (testLine != null)
            {
                LineSegment2DF line = (LineSegment2DF)testLine;
                image.Draw(line, new Gray(0.3 * lineColor.Red + 0.59 * lineColor.Green + 0.11 * lineColor.Blue), lineThickness);
            }
        }

        public void drawLine(Image<Hsv, byte> image, Rectangle bounds)
        {
            LineSegment2DF? testLine = getDrawnLine(bounds);
            if (testLine != null)
            {
                LineSegment2DF line = (LineSegment2DF)testLine;
                image.Draw(line, new Hsv(lineColor.Blue, lineColor.Green, lineColor.Red), lineThickness);
            }
        }

        public void drawLine(Image<Bgr, byte> image)
        {
            drawLine(image, new Rectangle(new Point(0, 0), image.Size));
        }

        public void drawLine(Image<Gray, byte> image)
        {
            drawLine(image, new Rectangle(new Point(0, 0), image.Size));
        }

        public void drawLine(Image<Hsv, byte> image)
        {
            drawLine(image, new Rectangle(new Point(0, 0), image.Size));
        }

        //Methods for setting line drawing variables, such as color and thickness
        public void setLineColor(Bgr newColor)
        {
            this.lineColor = newColor;
        }

        public void setLineColor(Hsv newColor)
        {
            this.lineColor = new Bgr(newColor.Hue, newColor.Satuation, newColor.Value);
        }

        public void setLineThickness(int newThickness)
        {
            lineThickness = newThickness;

            if(lineThickness < 1)
            {
                lineThickness = 1;
            }
        }

        public void setLine(Line line)
        {
            this.slope = line.slope;
            this.offset = line.offset;
            this.isVertical = line.isVertical;
        }

        //Methods for getting various types of lines.

        public static Line getVerticalLine(double xOffset)
        {
            Line line = new Line();
            line.slope = 0;
            line.offset = xOffset;
            return line;
        }

        public static Line getHorizontalLine(double yOffset)
        {
            return new Line(0, yOffset);
        }

        //Unit circle: 0 degrees is to the east, 90 to the north, 180 to the west. angle in radians.
        public static Line getLineFromAngle(double angle)
        {
            return new Line(Math.Tan(angle), 0);
        }

   /*     public static Line getLineFromPoints(Point p1, Point p2)
        {
            double slope = (double)(p2.Y - p1.Y) / (double)(p2.X - p1.X);
            if (double.IsNaN(slope))
            {
                //Vertical line, ugh
                return new Line(slope, p1.X);
            }else
            {
                double offset = p1.Y - slope * p1.X;
                return new Line(slope, offset);
            }
        }*/

        //Unit circle: 0 degrees is to the east, 90 to the north, 180 to the west. angle in radians.
        public static Line getLineFromAngle(double angle, double yOffset)
        {
            Line newLine = new Line(Math.Tan(angle), yOffset);
            if (newLine.isVertical)
            {
                newLine.offset = 0;
            }
            return newLine;
        }

        public static Line averageLines(List<Line> lines)
        {
            double avgSlope = 0;
            double avgOffset = 0; //In case of vertical line condition
            int count = 0;

            foreach (Line line in lines)
            {
                if (line.isVertical)
                {
                    continue;
                }
                else {
                    avgSlope += line.slope;
                    avgOffset += line.offset;
                    count++;
                }
            }

            Line newLine = new Line(avgSlope / count, avgOffset / count);

            if (newLine.isVertical)
            {
                return null;
            }

            return newLine;
        }

    }
}
