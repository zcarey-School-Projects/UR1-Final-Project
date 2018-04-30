using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InClassTurningAsignment
{
    public partial class EdgeOptions : Form
    {
        private static float MAX_GAP_INIT = 40f;
        private static float MIN_LINE_LENGTH_INIT = 150f;

        private Vision vision;

        public EdgeOptions(Vision vision)
        {
            InitializeComponent();
            this.vision = vision;

            initializeValues();
            initializeSliders();
        }

        private void initializeValues()
        {
            MaxGapSlider.Value = (int)(MAX_GAP_INIT * 100);
            MinLengthSlider.Value = (int)(MIN_LINE_LENGTH_INIT * 100);
        }

        private void initializeSliders()
        {
            MaxGapSlider_Scroll(null, null);
            MinLengthSlider_Scroll(null, null);
        }

        private void EdgeOptions_Load(object sender, EventArgs e)
        {

        }

        private void EdgeOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void setSliderValue(TrackBar slider, Label label, Vision.Variable variable, String prefix, String suffix = "")
        {
            float val = slider.Value / 100f;
            label.Text = prefix + val + suffix;
            vision.setVariable(variable, val);
        }

        private void MaxGapSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(MaxGapSlider, MaxGapText, Vision.Variable.MaxLineGap, "Max Line Gap: ");
        }

        private void MinLengthSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(MinLengthSlider, MinLengthText, Vision.Variable.MinLineLength, "Min Line Length: ");
        }
    }
}
