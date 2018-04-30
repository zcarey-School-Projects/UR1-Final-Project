namespace InClassTurningAsignment
{
    partial class RedSquareOptions
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
            this.LowHueText = new System.Windows.Forms.Label();
            this.LowHueSlider = new System.Windows.Forms.TrackBar();
            this.HighHueText = new System.Windows.Forms.Label();
            this.HighHueSlider = new System.Windows.Forms.TrackBar();
            this.HighSatText = new System.Windows.Forms.Label();
            this.HighSatSlider = new System.Windows.Forms.TrackBar();
            this.LowSatText = new System.Windows.Forms.Label();
            this.LowSatSlider = new System.Windows.Forms.TrackBar();
            this.HighValText = new System.Windows.Forms.Label();
            this.HighValSlider = new System.Windows.Forms.TrackBar();
            this.LowValText = new System.Windows.Forms.Label();
            this.LowValSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.LowHueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighHueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighSatSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowSatSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighValSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowValSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // LowHueText
            // 
            this.LowHueText.AutoSize = true;
            this.LowHueText.Location = new System.Drawing.Point(418, 12);
            this.LowHueText.Name = "LowHueText";
            this.LowHueText.Size = new System.Drawing.Size(107, 17);
            this.LowHueText.TabIndex = 8;
            this.LowHueText.Text = "Low Hue Value:";
            // 
            // LowHueSlider
            // 
            this.LowHueSlider.Location = new System.Drawing.Point(12, 12);
            this.LowHueSlider.Maximum = 18000;
            this.LowHueSlider.Name = "LowHueSlider";
            this.LowHueSlider.Size = new System.Drawing.Size(400, 56);
            this.LowHueSlider.TabIndex = 7;
            this.LowHueSlider.Value = 800;
            this.LowHueSlider.Scroll += new System.EventHandler(this.LowHueSlider_Scroll);
            // 
            // HighHueText
            // 
            this.HighHueText.AutoSize = true;
            this.HighHueText.Location = new System.Drawing.Point(418, 74);
            this.HighHueText.Name = "HighHueText";
            this.HighHueText.Size = new System.Drawing.Size(111, 17);
            this.HighHueText.TabIndex = 10;
            this.HighHueText.Text = "High Hue Value:";
            // 
            // HighHueSlider
            // 
            this.HighHueSlider.Location = new System.Drawing.Point(12, 74);
            this.HighHueSlider.Maximum = 18000;
            this.HighHueSlider.Name = "HighHueSlider";
            this.HighHueSlider.Size = new System.Drawing.Size(400, 56);
            this.HighHueSlider.TabIndex = 9;
            this.HighHueSlider.Value = 800;
            this.HighHueSlider.Scroll += new System.EventHandler(this.HighHueSlider_Scroll);
            // 
            // HighSatText
            // 
            this.HighSatText.AutoSize = true;
            this.HighSatText.Location = new System.Drawing.Point(418, 198);
            this.HighSatText.Name = "HighSatText";
            this.HighSatText.Size = new System.Drawing.Size(106, 17);
            this.HighSatText.TabIndex = 14;
            this.HighSatText.Text = "High Sat Value:";
            // 
            // HighSatSlider
            // 
            this.HighSatSlider.Location = new System.Drawing.Point(12, 198);
            this.HighSatSlider.Maximum = 25500;
            this.HighSatSlider.Name = "HighSatSlider";
            this.HighSatSlider.Size = new System.Drawing.Size(400, 56);
            this.HighSatSlider.TabIndex = 13;
            this.HighSatSlider.Value = 800;
            this.HighSatSlider.Scroll += new System.EventHandler(this.HighSatSlider_Scroll);
            // 
            // LowSatText
            // 
            this.LowSatText.AutoSize = true;
            this.LowSatText.Location = new System.Drawing.Point(418, 136);
            this.LowSatText.Name = "LowSatText";
            this.LowSatText.Size = new System.Drawing.Size(102, 17);
            this.LowSatText.TabIndex = 12;
            this.LowSatText.Text = "Low Sat Value:";
            // 
            // LowSatSlider
            // 
            this.LowSatSlider.Location = new System.Drawing.Point(12, 136);
            this.LowSatSlider.Maximum = 25500;
            this.LowSatSlider.Name = "LowSatSlider";
            this.LowSatSlider.Size = new System.Drawing.Size(400, 56);
            this.LowSatSlider.TabIndex = 11;
            this.LowSatSlider.Value = 800;
            this.LowSatSlider.Scroll += new System.EventHandler(this.LowSatSlider_Scroll);
            // 
            // HighValText
            // 
            this.HighValText.AutoSize = true;
            this.HighValText.Location = new System.Drawing.Point(418, 322);
            this.HighValText.Name = "HighValText";
            this.HighValText.Size = new System.Drawing.Size(106, 17);
            this.HighValText.TabIndex = 18;
            this.HighValText.Text = "High Sat Value:";
            // 
            // HighValSlider
            // 
            this.HighValSlider.Location = new System.Drawing.Point(12, 322);
            this.HighValSlider.Maximum = 25500;
            this.HighValSlider.Name = "HighValSlider";
            this.HighValSlider.Size = new System.Drawing.Size(400, 56);
            this.HighValSlider.TabIndex = 17;
            this.HighValSlider.Value = 800;
            this.HighValSlider.Scroll += new System.EventHandler(this.HighValSlider_Scroll);
            // 
            // LowValText
            // 
            this.LowValText.AutoSize = true;
            this.LowValText.Location = new System.Drawing.Point(418, 260);
            this.LowValText.Name = "LowValText";
            this.LowValText.Size = new System.Drawing.Size(102, 17);
            this.LowValText.TabIndex = 16;
            this.LowValText.Text = "Low Sat Value:";
            // 
            // LowValSlider
            // 
            this.LowValSlider.Location = new System.Drawing.Point(12, 260);
            this.LowValSlider.Maximum = 25500;
            this.LowValSlider.Name = "LowValSlider";
            this.LowValSlider.Size = new System.Drawing.Size(400, 56);
            this.LowValSlider.TabIndex = 15;
            this.LowValSlider.Value = 800;
            this.LowValSlider.Scroll += new System.EventHandler(this.LowValSlider_Scroll);
            // 
            // RedSquareOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 404);
            this.Controls.Add(this.HighValText);
            this.Controls.Add(this.HighValSlider);
            this.Controls.Add(this.LowValText);
            this.Controls.Add(this.LowValSlider);
            this.Controls.Add(this.HighSatText);
            this.Controls.Add(this.HighSatSlider);
            this.Controls.Add(this.LowSatText);
            this.Controls.Add(this.LowSatSlider);
            this.Controls.Add(this.HighHueText);
            this.Controls.Add(this.HighHueSlider);
            this.Controls.Add(this.LowHueText);
            this.Controls.Add(this.LowHueSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RedSquareOptions";
            this.Text = "Red Square Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HueOptions_FormClosing);
            this.Load += new System.EventHandler(this.HueOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LowHueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighHueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighSatSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowSatSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighValSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowValSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LowHueText;
        private System.Windows.Forms.TrackBar LowHueSlider;
        private System.Windows.Forms.Label HighHueText;
        private System.Windows.Forms.TrackBar HighHueSlider;
        private System.Windows.Forms.Label HighSatText;
        private System.Windows.Forms.TrackBar HighSatSlider;
        private System.Windows.Forms.Label LowSatText;
        private System.Windows.Forms.TrackBar LowSatSlider;
        private System.Windows.Forms.Label HighValText;
        private System.Windows.Forms.TrackBar HighValSlider;
        private System.Windows.Forms.Label LowValText;
        private System.Windows.Forms.TrackBar LowValSlider;
    }
}