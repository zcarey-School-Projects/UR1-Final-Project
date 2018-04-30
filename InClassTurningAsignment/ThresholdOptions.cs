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
    public partial class ThresholdOptions : Form
    {
        private static float SATURATION_INIT = 180f;
        private static float VALUE_INIT = 195f;
        private static float ANGLE_INIT = -25f;
        private static float SEPARATION_INIT = 50f;
        private static float Y_INIT = 28.8f;

        private Vision vision;

        public ThresholdOptions(Vision vision)
        {
            InitializeComponent();
            this.vision = vision;

            initializeValues();
            initializeSliders();
        }

        private void initializeValues()
        {
            SaturationSlider.Value = (int) (SATURATION_INIT * 100);
            ValueSlider.Value = (int)(VALUE_INIT * 100);
            AngleSlider.Value = (int)(ANGLE_INIT * 100);
            SeparationSlider.Value = (int)(SEPARATION_INIT * 100);
            YSlider.Value = (int)(Y_INIT * 100);
        }

        private void initializeSliders()
        {
            SaturationSlider_Scroll(null, null);
            ValueSlider_Scroll(null, null);
            AngleSlider_Scroll(null, null);
            SeparationSlider_Scroll(null, null);
            YSlider_Scroll(null, null);
        }

        private void ThresholdOptions_Load(object sender, EventArgs e)
        {

        }

        private void ThresholdOptions_FormClosing(object sender, FormClosingEventArgs e)
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

        private void SaturationSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(SaturationSlider, SaturationText, Vision.Variable.SaturationThreshold, "Saturation Threshold: ");
        }

        private void ValueSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(ValueSlider, ValueText, Vision.Variable.ValueThreshold, "Value Threshold: ");
        }

        private void AngleSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(AngleSlider, AngleText, Vision.Variable.AngleThreshold, "Angle Threshold: ", "" + ((char) 167));
        }

        private void SeparationSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(SeparationSlider, SeparationText, Vision.Variable.ThresholdSeparationPercent, "Separation: ", "%");
        }

        private void YSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(YSlider, YText, Vision.Variable.YThresholdPercent, "Y: ", "%");
        }

    }
}
