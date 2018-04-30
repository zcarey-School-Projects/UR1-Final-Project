namespace InClassTurningAsignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OriginalImage = new System.Windows.Forms.PictureBox();
            this.ThresholdImage = new System.Windows.Forms.PictureBox();
            this.NativeResolutionLabel = new System.Windows.Forms.Label();
            this.MaskedImage = new System.Windows.Forms.PictureBox();
            this.RobotSerial = new System.IO.Ports.SerialPort(this.components);
            this.SerialPorts = new System.Windows.Forms.ComboBox();
            this.OverrideControls = new System.Windows.Forms.CheckBox();
            this.TurnLeft = new System.Windows.Forms.Button();
            this.TurnForward = new System.Windows.Forms.Button();
            this.TurnRight = new System.Windows.Forms.Button();
            this.DisconnectSerial = new System.Windows.Forms.Button();
            this.ConnectedStatus = new System.Windows.Forms.CheckBox();
            this.EqualizeHist = new System.Windows.Forms.CheckBox();
            this.Erosion = new System.Windows.Forms.CheckBox();
            this.Dialation = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskedImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalImage
            // 
            this.OriginalImage.Location = new System.Drawing.Point(12, 27);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(400, 300);
            this.OriginalImage.TabIndex = 0;
            this.OriginalImage.TabStop = false;
            // 
            // ThresholdImage
            // 
            this.ThresholdImage.Location = new System.Drawing.Point(418, 27);
            this.ThresholdImage.Name = "ThresholdImage";
            this.ThresholdImage.Size = new System.Drawing.Size(400, 300);
            this.ThresholdImage.TabIndex = 1;
            this.ThresholdImage.TabStop = false;
            // 
            // NativeResolutionLabel
            // 
            this.NativeResolutionLabel.AutoSize = true;
            this.NativeResolutionLabel.Location = new System.Drawing.Point(12, 330);
            this.NativeResolutionLabel.Name = "NativeResolutionLabel";
            this.NativeResolutionLabel.Size = new System.Drawing.Size(127, 17);
            this.NativeResolutionLabel.TabIndex = 2;
            this.NativeResolutionLabel.Text = "Native Resolution: ";
            // 
            // MaskedImage
            // 
            this.MaskedImage.Location = new System.Drawing.Point(824, 27);
            this.MaskedImage.Name = "MaskedImage";
            this.MaskedImage.Size = new System.Drawing.Size(400, 300);
            this.MaskedImage.TabIndex = 7;
            this.MaskedImage.TabStop = false;
            // 
            // RobotSerial
            // 
            this.RobotSerial.BaudRate = 115200;
            this.RobotSerial.ReadTimeout = 500;
            this.RobotSerial.WriteTimeout = 100;
            // 
            // SerialPorts
            // 
            this.SerialPorts.FormattingEnabled = true;
            this.SerialPorts.Location = new System.Drawing.Point(12, 689);
            this.SerialPorts.Name = "SerialPorts";
            this.SerialPorts.Size = new System.Drawing.Size(121, 24);
            this.SerialPorts.TabIndex = 17;
            this.SerialPorts.DropDown += new System.EventHandler(this.SerialPorts_DropDown);
            this.SerialPorts.SelectedIndexChanged += new System.EventHandler(this.SerialPorts_SelectedIndexChanged);
            // 
            // OverrideControls
            // 
            this.OverrideControls.AutoSize = true;
            this.OverrideControls.Checked = true;
            this.OverrideControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverrideControls.Location = new System.Drawing.Point(418, 663);
            this.OverrideControls.Name = "OverrideControls";
            this.OverrideControls.Size = new System.Drawing.Size(85, 21);
            this.OverrideControls.TabIndex = 18;
            this.OverrideControls.Text = "Override";
            this.OverrideControls.UseVisualStyleBackColor = true;
            this.OverrideControls.CheckedChanged += new System.EventHandler(this.OverrideControls_CheckedChanged);
            // 
            // TurnLeft
            // 
            this.TurnLeft.Location = new System.Drawing.Point(418, 690);
            this.TurnLeft.Name = "TurnLeft";
            this.TurnLeft.Size = new System.Drawing.Size(75, 23);
            this.TurnLeft.TabIndex = 19;
            this.TurnLeft.Text = "Left";
            this.TurnLeft.UseVisualStyleBackColor = true;
            this.TurnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TurnLeft_MouseDown);
            this.TurnLeft.MouseLeave += new System.EventHandler(this.TurnLeft_MouseLeave);
            this.TurnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TurnLeft_MouseUp);
            // 
            // TurnForward
            // 
            this.TurnForward.Location = new System.Drawing.Point(499, 690);
            this.TurnForward.Name = "TurnForward";
            this.TurnForward.Size = new System.Drawing.Size(75, 23);
            this.TurnForward.TabIndex = 20;
            this.TurnForward.Text = "Forward";
            this.TurnForward.UseVisualStyleBackColor = true;
            this.TurnForward.Click += new System.EventHandler(this.TurnForward_Click);
            this.TurnForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TurnForward_MouseDown);
            this.TurnForward.MouseLeave += new System.EventHandler(this.TurnForward_MouseLeave);
            this.TurnForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TurnForward_MouseUp);
            // 
            // TurnRight
            // 
            this.TurnRight.Location = new System.Drawing.Point(580, 690);
            this.TurnRight.Name = "TurnRight";
            this.TurnRight.Size = new System.Drawing.Size(75, 23);
            this.TurnRight.TabIndex = 21;
            this.TurnRight.Text = "Right";
            this.TurnRight.UseVisualStyleBackColor = true;
            this.TurnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TurnRight_MouseDown);
            this.TurnRight.MouseLeave += new System.EventHandler(this.TurnRight_MouseLeave);
            this.TurnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TurnRight_MouseUp);
            // 
            // DisconnectSerial
            // 
            this.DisconnectSerial.Location = new System.Drawing.Point(139, 690);
            this.DisconnectSerial.Name = "DisconnectSerial";
            this.DisconnectSerial.Size = new System.Drawing.Size(104, 23);
            this.DisconnectSerial.TabIndex = 22;
            this.DisconnectSerial.Text = "Disconnect";
            this.DisconnectSerial.UseVisualStyleBackColor = true;
            this.DisconnectSerial.Click += new System.EventHandler(this.DisconnectSerial_Click);
            // 
            // ConnectedStatus
            // 
            this.ConnectedStatus.AutoCheck = false;
            this.ConnectedStatus.AutoSize = true;
            this.ConnectedStatus.Location = new System.Drawing.Point(15, 663);
            this.ConnectedStatus.Name = "ConnectedStatus";
            this.ConnectedStatus.Size = new System.Drawing.Size(98, 21);
            this.ConnectedStatus.TabIndex = 25;
            this.ConnectedStatus.Text = "Connected";
            this.ConnectedStatus.UseVisualStyleBackColor = true;
            // 
            // EqualizeHist
            // 
            this.EqualizeHist.AutoSize = true;
            this.EqualizeHist.Location = new System.Drawing.Point(824, 333);
            this.EqualizeHist.Name = "EqualizeHist";
            this.EqualizeHist.Size = new System.Drawing.Size(112, 21);
            this.EqualizeHist.TabIndex = 26;
            this.EqualizeHist.Text = "Equalize Hist";
            this.EqualizeHist.UseVisualStyleBackColor = true;
            this.EqualizeHist.CheckedChanged += new System.EventHandler(this.EqualizeHist_CheckedChanged);
            // 
            // Erosion
            // 
            this.Erosion.AutoSize = true;
            this.Erosion.Checked = true;
            this.Erosion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Erosion.Location = new System.Drawing.Point(824, 360);
            this.Erosion.Name = "Erosion";
            this.Erosion.Size = new System.Drawing.Size(68, 21);
            this.Erosion.TabIndex = 27;
            this.Erosion.Text = "Erode";
            this.Erosion.UseVisualStyleBackColor = true;
            this.Erosion.CheckedChanged += new System.EventHandler(this.Erosion_CheckedChanged);
            // 
            // Dialation
            // 
            this.Dialation.AutoSize = true;
            this.Dialation.Checked = true;
            this.Dialation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Dialation.Location = new System.Drawing.Point(824, 387);
            this.Dialation.Name = "Dialation";
            this.Dialation.Size = new System.Drawing.Size(66, 21);
            this.Dialation.TabIndex = 28;
            this.Dialation.Text = "Dilate";
            this.Dialation.UseVisualStyleBackColor = true;
            this.Dialation.CheckedChanged += new System.EventHandler(this.Dialation_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1241, 28);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.loadToolStripMenuItem1});
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.cameraToolStripMenuItem.Text = "Input";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem1
            // 
            this.cameraToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.cameraToolStripMenuItem1.Name = "cameraToolStripMenuItem1";
            this.cameraToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.cameraToolStripMenuItem1.Text = "Camera";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem2.Text = "0";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem3.Text = "1";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem4.Text = "2";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultsToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.loadToolStripMenuItem.Text = "Video";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // defaultsToolStripMenuItem
            // 
            this.defaultsToolStripMenuItem.Name = "defaultsToolStripMenuItem";
            this.defaultsToolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.defaultsToolStripMenuItem.Text = "1";
            this.defaultsToolStripMenuItem.Click += new System.EventHandler(this.defaultsToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem5.Text = "1";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem6.Text = "2";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem7.Text = "3";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem8.Text = "4";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem9.Text = "5";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(92, 26);
            this.toolStripMenuItem10.Text = "6";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thresholdingToolStripMenuItem,
            this.edgesToolStripMenuItem,
            this.hueToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // thresholdingToolStripMenuItem
            // 
            this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
            this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.thresholdingToolStripMenuItem.Text = "Thresholding";
            this.thresholdingToolStripMenuItem.Click += new System.EventHandler(this.thresholdingToolStripMenuItem_Click);
            // 
            // edgesToolStripMenuItem
            // 
            this.edgesToolStripMenuItem.Name = "edgesToolStripMenuItem";
            this.edgesToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.edgesToolStripMenuItem.Text = "Edges";
            this.edgesToolStripMenuItem.Click += new System.EventHandler(this.edgesToolStripMenuItem_Click);
            // 
            // hueToolStripMenuItem
            // 
            this.hueToolStripMenuItem.Name = "hueToolStripMenuItem";
            this.hueToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.hueToolStripMenuItem.Text = "Hue";
            this.hueToolStripMenuItem.Click += new System.EventHandler(this.hueToolStripMenuItem_Click);
            // 
            // RedImage
            // 
            this.RedImage.Location = new System.Drawing.Point(418, 333);
            this.RedImage.Name = "RedImage";
            this.RedImage.Size = new System.Drawing.Size(400, 300);
            this.RedImage.TabIndex = 32;
            this.RedImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 808);
            this.Controls.Add(this.RedImage);
            this.Controls.Add(this.Dialation);
            this.Controls.Add(this.Erosion);
            this.Controls.Add(this.EqualizeHist);
            this.Controls.Add(this.ConnectedStatus);
            this.Controls.Add(this.DisconnectSerial);
            this.Controls.Add(this.TurnRight);
            this.Controls.Add(this.TurnForward);
            this.Controls.Add(this.TurnLeft);
            this.Controls.Add(this.OverrideControls);
            this.Controls.Add(this.SerialPorts);
            this.Controls.Add(this.MaskedImage);
            this.Controls.Add(this.NativeResolutionLabel);
            this.Controls.Add(this.ThresholdImage);
            this.Controls.Add(this.OriginalImage);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskedImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalImage;
        private System.Windows.Forms.PictureBox ThresholdImage;
        private System.Windows.Forms.Label NativeResolutionLabel;
        private System.Windows.Forms.PictureBox MaskedImage;
        private System.IO.Ports.SerialPort RobotSerial;
        private System.Windows.Forms.ComboBox SerialPorts;
        private System.Windows.Forms.CheckBox OverrideControls;
        private System.Windows.Forms.Button TurnLeft;
        private System.Windows.Forms.Button TurnForward;
        private System.Windows.Forms.Button TurnRight;
        private System.Windows.Forms.Button DisconnectSerial;
        private System.Windows.Forms.CheckBox ConnectedStatus;
        private System.Windows.Forms.CheckBox EqualizeHist;
        private System.Windows.Forms.CheckBox Erosion;
        private System.Windows.Forms.CheckBox Dialation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgesToolStripMenuItem;
        private System.Windows.Forms.PictureBox RedImage;
    }
}

