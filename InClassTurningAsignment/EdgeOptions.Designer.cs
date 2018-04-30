namespace InClassTurningAsignment
{
    partial class EdgeOptions
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
            this.MaxGapText = new System.Windows.Forms.Label();
            this.MaxGapSlider = new System.Windows.Forms.TrackBar();
            this.MinLengthText = new System.Windows.Forms.Label();
            this.MinLengthSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGapSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinLengthSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // MaxGapText
            // 
            this.MaxGapText.AutoSize = true;
            this.MaxGapText.Location = new System.Drawing.Point(418, 12);
            this.MaxGapText.Name = "MaxGapText";
            this.MaxGapText.Size = new System.Drawing.Size(103, 17);
            this.MaxGapText.TabIndex = 8;
            this.MaxGapText.Text = "Max Line Gap: ";
            // 
            // MaxGapSlider
            // 
            this.MaxGapSlider.Location = new System.Drawing.Point(12, 12);
            this.MaxGapSlider.Maximum = 20000;
            this.MaxGapSlider.Name = "MaxGapSlider";
            this.MaxGapSlider.Size = new System.Drawing.Size(400, 56);
            this.MaxGapSlider.TabIndex = 7;
            this.MaxGapSlider.Value = 800;
            this.MaxGapSlider.Scroll += new System.EventHandler(this.MaxGapSlider_Scroll);
            // 
            // MinLengthText
            // 
            this.MinLengthText.AutoSize = true;
            this.MinLengthText.Location = new System.Drawing.Point(418, 74);
            this.MinLengthText.Name = "MinLengthText";
            this.MinLengthText.Size = new System.Drawing.Size(113, 17);
            this.MinLengthText.TabIndex = 10;
            this.MinLengthText.Text = "Min Line Length:";
            // 
            // MinLengthSlider
            // 
            this.MinLengthSlider.Location = new System.Drawing.Point(12, 74);
            this.MinLengthSlider.Maximum = 30000;
            this.MinLengthSlider.Minimum = 1000;
            this.MinLengthSlider.Name = "MinLengthSlider";
            this.MinLengthSlider.Size = new System.Drawing.Size(400, 56);
            this.MinLengthSlider.TabIndex = 9;
            this.MinLengthSlider.Value = 2500;
            this.MinLengthSlider.Scroll += new System.EventHandler(this.MinLengthSlider_Scroll);
            // 
            // EdgeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 253);
            this.Controls.Add(this.MinLengthText);
            this.Controls.Add(this.MinLengthSlider);
            this.Controls.Add(this.MaxGapText);
            this.Controls.Add(this.MaxGapSlider);
            this.Name = "EdgeOptions";
            this.Text = "EdgeOptions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EdgeOptions_FormClosing);
            this.Load += new System.EventHandler(this.EdgeOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MaxGapSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinLengthSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MaxGapText;
        private System.Windows.Forms.TrackBar MaxGapSlider;
        private System.Windows.Forms.Label MinLengthText;
        private System.Windows.Forms.TrackBar MinLengthSlider;
    }
}