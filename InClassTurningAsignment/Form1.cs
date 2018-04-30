using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;
using Emgu.CV.CvEnum;
using System.IO.Ports;

namespace InClassTurningAsignment
{
    public partial class Form1 : Form
    {

        private Vision vision;
        private Robot robot;
        private String originalTitle;

        private RedSquareOptions hueWindow;
        private ThresholdOptions threshWindow;
        private EdgeOptions edgeWindow;

        public Form1()
        {
            InitializeComponent();
            robot = new Robot(this, this.RobotSerial);
            vision = new Vision(this, robot, 1);
            originalTitle = this.Text;

            hueWindow = new RedSquareOptions(vision);
            threshWindow = new ThresholdOptions(vision);
            edgeWindow = new EdgeOptions(vision);
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            EqualizeHist_CheckedChanged(null, null);
            Erosion_CheckedChanged(null, null);
            Dialation_CheckedChanged(null, null);

            vision.start();
        }

        public void displayImage(ref Image<Gray, byte> image, PictureId target)
        {
            PictureBox box = getPictureBoxFromId(target);
            box.Image = image.Resize(box.Width, box.Height, Emgu.CV.CvEnum.Inter.Linear).ToBitmap();
        }

        public void displayImage(ref Image<Bgr, byte> image, PictureId target)
        {
            PictureBox box = getPictureBoxFromId(target);
            box.Image = image.Resize(box.Size.Width, box.Size.Height, Emgu.CV.CvEnum.Inter.Linear).ToBitmap();
        }

        private PictureBox getPictureBoxFromId(PictureId id)
        {
            switch (id)
            {
                case PictureId.Original:
                    return OriginalImage;
                case PictureId.Threshold:
                    return ThresholdImage;
                case PictureId.Masked:
                    return MaskedImage;
                case PictureId.Red:
                    return RedImage;
                default:
                    return null;
            }
        }

        public enum PictureId
        {
            Original,
            Threshold,
            Masked,
            Red
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vision.stop();
        }

        private void EqualizeHist_CheckedChanged(object sender, EventArgs e)
        {
            vision.setVariable(Vision.Variable.EqualizeHistogram, EqualizeHist.Checked);
        }

        private void Erosion_CheckedChanged(object sender, EventArgs e)
        {
            vision.setVariable(Vision.Variable.Erode, Erosion.Checked);
        }

        private void Dialation_CheckedChanged(object sender, EventArgs e)
        {
            vision.setVariable(Vision.Variable.Dialate, Dialation.Checked);
        }

        public void setFPS(float FPS)
        {
            String fps = FPS.ToString();
            int index = fps.IndexOf('.');
            if (index >= 0)
            {
                int endIndex = index + Options.FPS_DecimalHolder + 1;
                if (endIndex > fps.Length)
                {
                    endIndex = fps.Length;
                }

                fps = fps.Substring(0, endIndex);
                int spacesNeeded = Options.FPS_DigitHolder - index;
                while(spacesNeeded-- > 0)
                {
                    fps = " " + fps;
                }
            }else
            {
                int spacesNeeded = Options.FPS_DigitHolder - fps.Length;
                while(spacesNeeded-- > 0)
                {
                    fps = " " + fps;
                }
            }

            this.Text = originalTitle + "; FPS: " + fps;
        }

        private void SerialPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selection = SerialPorts.Text;

            if (robot.isOpen())
            {
                robot.close();
            }

            if (selection != null && selection != "")
            {
                if (robot.open(selection))
                {
                    return;
                }
            }

            SerialPorts.Text = "";
        }

        private void SerialPorts_DropDown(object sender, EventArgs e)
        {
            String[] portNames = robot.getAvailablePorts();
            SerialPorts.Items.Clear();
            SerialPorts.Items.AddRange(portNames);
        }

        private void DisconnectSerial_Click(object sender, EventArgs e)
        {
            SerialPorts.Text = "";
            robot.close();
        }

        private void OverrideControls_CheckedChanged(object sender, EventArgs e)
        {
            robot.setOverrideStatus(OverrideControls.Checked);
        }

        private void TurnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Left);
        }

        private void TurnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        private void TurnLeft_MouseLeave(object sender, EventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        private void TurnForward_MouseDown(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Forward);
        }

        private void TurnForward_MouseUp(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        private void TurnForward_MouseLeave(object sender, EventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        private void TurnRight_MouseDown(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Right);
        }

        private void TurnRight_MouseUp(object sender, MouseEventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        private void TurnRight_MouseLeave(object sender, EventArgs e)
        {
            robot.sendOverrideCommand(Robot.Command.Stop);
        }

        public void setResolutionText(String txt)
        {
            NativeResolutionLabel.Text = txt;
        }

        public void setConnectedBox(bool state)
        {
            ConnectedStatus.Checked = state;
        }

        private bool spaceDB = true;
        private bool left = false;
        private bool right = false;
        private bool up = false;
        private bool down = false;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(spaceDB && e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                spaceDB = false;
                OverrideControls.Checked = !OverrideControls.Checked;
            }else if(setKeyValue(e, true))
            {
                moveRobot();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                spaceDB = true;
                e.Handled = true;
            }else if(setKeyValue(e, false))
            {
                moveRobot();
            }
        }

        private void moveRobot()
        {
            Robot.Command cmd = Robot.Command.Stop;

            if ((up ^ down) && !(left ^ right)) //Up or down is pressed, and not left or right
            {
                if (up)
                {
                    cmd = Robot.Command.Forward;
                }
            }else if ((left ^ right) && !(up ^ down)) //Left or right is pressed, and not up or down.
            {
                if (left)
                {
                    cmd = Robot.Command.Left;
                }else
                {
                    cmd = Robot.Command.Right;
                }
            }

            robot.sendOverrideCommand(cmd);
        }

        private bool setKeyValue(KeyEventArgs e, bool value)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    up = true;
                    break;
                case Keys.S:
                    down = true;
                    break;
                case Keys.A:
                    left = true;
                    break;
                case Keys.D:
                    right = true;
                    break;
                default:
                    return false;
            }

            e.Handled = true;
            return true;
        }

        private void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadVideo("v1");
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vision.loadInput();
        }

        private bool loadCamera(int cam)
        {
            return vision.setCamera(cam);
        }

        private bool loadVideo(String name)
        {
            return vision.setVideo("VideoFiles\\" + name);
        }

        private bool loadImage(String name)
        {
            return vision.setImage("VideoFiles\\" + name);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadCamera(0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            loadCamera(1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            loadCamera(2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            loadImage("s1");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            loadImage("s2");
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            loadImage("s3");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            loadImage("s4");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            loadImage("s5");
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            loadImage("s6");
        }


        private void hueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hueWindow.Show();
        }

        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threshWindow.Show();
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edgeWindow.Show();
        }

        private void TurnForward_Click(object sender, EventArgs e)
        {

        }
    }
}
