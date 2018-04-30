using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.CvEnum;

namespace InClassTurningAsignment
{
    class Options
    {

        //Options - Educated Line
        public static int MedianLineLength = 5;
        public static Bgr MedianLineColor = new Bgr(255, 0, 0);
        public static Bgr BestFitColor = new Bgr(0, 255, 255);
        public static int BestFitThickness = 2;

        //Options - Threshold Lines
        public static Bgr ThresholdLineColor = new Bgr(0, 255, 0);
        public static int ThresholdLineThickness = 2;
        public static Bgr YThresholdLineColor = new Bgr(0, 255, 0); //new Bgra(0, 0, 255, 191.25f);
        public static int YThresholdLineThickness = 2;

        //Options - Center Line
        public static Bgr CenterLineColor = new Bgr(127, 127, 127);
        public static int CenterLineThickness = 2;

        //Options - FPS
        public static int FPS_NumFramesToAvg = 10;
        public static int FPS_DecimalHolder = 2;
        public static int FPS_DigitHolder = 3;

    }
}
