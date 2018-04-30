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
    public partial class RedSquareOptions : Form
    {
        private static float LOW_HUE_INIT = 165f;
        private static float HIGH_HUE_INIT = 15f;
        private static float LOW_SAT_INIT = 148f; //228
        private static float HIGH_SAT_INIT = 255f;
        private static float LOW_VAL_INIT = 207f;
        private static float HIGH_VAL_INIT = 255f;

        private Vision vision;

        public RedSquareOptions(Vision vision)
        {
            InitializeComponent();
            this.vision = vision;

            initializeValues();
            initializeSliders();
        }

        private void initializeValues()
        {
            LowHueSlider.Value = (int)(LOW_HUE_INIT * 100);
            HighHueSlider.Value = (int)(HIGH_HUE_INIT * 100);
            LowSatSlider.Value = (int)(LOW_SAT_INIT * 100);
            HighSatSlider.Value = (int)(HIGH_SAT_INIT * 100);
            LowValSlider.Value = (int)(LOW_VAL_INIT * 100);
            HighValSlider.Value = (int)(HIGH_VAL_INIT * 100);
        }

        private void initializeSliders()
        {
            LowHueSlider_Scroll(null, null);
            HighHueSlider_Scroll(null, null);
            LowSatSlider_Scroll(null, null);
            HighSatSlider_Scroll(null, null);
            LowValSlider_Scroll(null, null);
            HighValSlider_Scroll(null, null);
        }

        private void HueOptions_Load(object sender, EventArgs e)
        {
            
        }

        private void HueOptions_FormClosing(object sender, FormClosingEventArgs e)
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

        private void LowHueSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(LowHueSlider, LowHueText, Vision.Variable.LowSquareHue, "Low Hue: ", "" + ((char)167));
        }

        private void HighHueSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(HighHueSlider, HighHueText, Vision.Variable.HighSquareHue, "High Hue: ", "" + ((char)167));
        }

        private void LowSatSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(LowSatSlider, LowSatText, Vision.Variable.LowSquareSaturation, "Low Saturation: ");
        }

        private void HighSatSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(HighSatSlider, HighSatText, Vision.Variable.HighSquareSaturation, "High Saturation: ");
        }

        private void LowValSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(LowValSlider, LowValText, Vision.Variable.LowSquareValue, "Low Value: ");
        }

        private void HighValSlider_Scroll(object sender, EventArgs e)
        {
            setSliderValue(HighValSlider, HighValText, Vision.Variable.HighSquareValue, "High Value: ");
        }
    }
}
