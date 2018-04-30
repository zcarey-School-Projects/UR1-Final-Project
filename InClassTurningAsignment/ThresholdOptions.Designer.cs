namespace InClassTurningAsignment
{
    partial class ThresholdOptions
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
            this.SaturationSlider = new System.Windows.Forms.TrackBar();
            this.SaturationText = new System.Windows.Forms.Label();
            this.ValueSlider = new System.Windows.Forms.TrackBar();
            this.ValueText = new System.Windows.Forms.Label();
            this.AngleSlider = new System.Windows.Forms.TrackBar();
            this.AngleText = new System.Windows.Forms.Label();
            this.SeparationSlider = new System.Windows.Forms.TrackBar();
            this.SeparationText = new System.Windows.Forms.Label();
            this.YSlider = new System.Windows.Forms.TrackBar();
            this.YText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeparationSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // SaturationSlider
            // 
            this.SaturationSlider.Location = new System.Drawing.Point(12, 12);
            this.SaturationSlider.Maximum = 25500;
            this.SaturationSlider.Name = "SaturationSlider";
            this.SaturationSlider.Size = new System.Drawing.Size(400, 56);
            this.SaturationSlider.TabIndex = 4;
            this.SaturationSlider.Value = 800;
            this.SaturationSlider.Scroll += new System.EventHandler(this.SaturationSlider_Scroll);
            // 
            // SaturationText
            // 
            this.SaturationText.AutoSize = true;
            this.SaturationText.Location = new System.Drawing.Point(418, 12);
            this.SaturationText.Name = "SaturationText";
            this.SaturationText.Size = new System.Drawing.Size(149, 17);
            this.SaturationText.TabIndex = 6;
            this.SaturationText.Text = "Saturation Threshold: ";
            // 
            // ValueSlider
            // 
            this.ValueSlider.Location = new System.Drawing.Point(12, 74);
            this.ValueSlider.Maximum = 25500;
            this.ValueSlider.Name = "ValueSlider";
            this.ValueSlider.Size = new System.Drawing.Size(400, 56);
            this.ValueSlider.TabIndex = 7;
            this.ValueSlider.Value = 800;
            this.ValueSlider.Scroll += new System.EventHandler(this.ValueSlider_Scroll);
            // 
            // ValueText
            // 
            this.ValueText.AutoSize = true;
            this.ValueText.Location = new System.Drawing.Point(418, 74);
            this.ValueText.Name = "ValueText";
            this.ValueText.Size = new System.Drawing.Size(120, 17);
            this.ValueText.TabIndex = 8;
            this.ValueText.Text = "Value Threshold: ";
            // 
            // AngleSlider
            // 
            this.AngleSlider.Location = new System.Drawing.Point(12, 136);
            this.AngleSlider.Maximum = 4500;
            this.AngleSlider.Minimum = -4500;
            this.AngleSlider.Name = "AngleSlider";
            this.AngleSlider.Size = new System.Drawing.Size(400, 56);
            this.AngleSlider.TabIndex = 9;
            this.AngleSlider.Value = 800;
            this.AngleSlider.Scroll += new System.EventHandler(this.AngleSlider_Scroll);
            // 
            // AngleText
            // 
            this.AngleText.AutoSize = true;
            this.AngleText.Location = new System.Drawing.Point(418, 136);
            this.AngleText.Name = "AngleText";
            this.AngleText.Size = new System.Drawing.Size(120, 17);
            this.AngleText.TabIndex = 10;
            this.AngleText.Text = "Angle Threshold: ";
            // 
            // SeparationSlider
            // 
            this.SeparationSlider.Location = new System.Drawing.Point(12, 198);
            this.SeparationSlider.Maximum = 10000;
            this.SeparationSlider.Name = "SeparationSlider";
            this.SeparationSlider.Size = new System.Drawing.Size(400, 56);
            this.SeparationSlider.TabIndex = 11;
            this.SeparationSlider.Value = 800;
            this.SeparationSlider.Scroll += new System.EventHandler(this.SeparationSlider_Scroll);
            // 
            // SeparationText
            // 
            this.SeparationText.AutoSize = true;
            this.SeparationText.Location = new System.Drawing.Point(418, 198);
            this.SeparationText.Name = "SeparationText";
            this.SeparationText.Size = new System.Drawing.Size(153, 17);
            this.SeparationText.TabIndex = 12;
            this.SeparationText.Text = "Separation Threshold: ";
            // 
            // YSlider
            // 
            this.YSlider.Location = new System.Drawing.Point(12, 260);
            this.YSlider.Maximum = 10000;
            this.YSlider.Name = "YSlider";
            this.YSlider.Size = new System.Drawing.Size(400, 56);
            this.YSlider.TabIndex = 13;
            this.YSlider.Value = 800;
            this.YSlider.Scroll += new System.EventHandler(this.YSlider_Scroll);
            // 
            // YText
            // 
            this.YText.AutoSize = true;
            this.YText.Location = new System.Drawing.Point(418, 260);
            this.YText.Name = "YText";
            this.YText.Size = new System.Drawing.Size(93, 17);
            this.YText.TabIndex = 14;
            this.YText.Text = "Y Threshold: ";
            // 
            // ThresholdOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 336);
            this.Controls.Add(this.YText);
            this.Controls.Add(this.YSlider);
            this.Controls.Add(this.SeparationText);
            this.Controls.Add(this.SeparationSlider);
            this.Controls.Add(this.AngleText);
            this.Controls.Add(this.AngleSlider);
            this.Controls.Add(this.ValueText);
            this.Controls.Add(this.ValueSlider);
            this.Controls.Add(this.SaturationText);
            this.Controls.Add(this.SaturationSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ThresholdOptions";
            this.Text = "ThresholdOptions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThresholdOptions_FormClosing);
            this.Load += new System.EventHandler(this.ThresholdOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaturationSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeparationSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar SaturationSlider;
        private System.Windows.Forms.Label SaturationText;
        private System.Windows.Forms.TrackBar ValueSlider;
        private System.Windows.Forms.Label ValueText;
        private System.Windows.Forms.TrackBar AngleSlider;
        private System.Windows.Forms.Label AngleText;
        private System.Windows.Forms.TrackBar SeparationSlider;
        private System.Windows.Forms.Label SeparationText;
        private System.Windows.Forms.TrackBar YSlider;
        private System.Windows.Forms.Label YText;
    }
}