using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassTurningAsignment
{
    class LinearRegression
    {
        int[] x;
        int[] y;
        int index = 0;
        double sumx = 0;
        double sumy = 0;
        double sumx2 = 0;

        public LinearRegression(int maxPoints){
            x = new int[maxPoints];
            y = new int[maxPoints];
        }

        public void addPoint(int x, int y)
        {
            //Flip X and Y points to prevent vertical line issues
            this.x[index] = x;
            this.y[index] = y;
            sumx += x;
            sumx2 += x * x;
            sumy += y;
            index++;
        }

        public Line getLine()
        {
            double xbar = sumx / index;
            double ybar = sumy / index;

            double xxbar = 0;
            double yybar = 0;
            double xybar = 0;
            for (int i = 0; i < index; i++)
            {
                xxbar += (x[i] - xbar) * (x[i] - xbar);
                yybar += (y[i] - ybar) * (y[i] - ybar);
                xybar += (x[i] - xbar) * (y[i] - ybar);
            }
            double beta1 = xybar / xxbar;
            double beta0 = ybar - beta1 * xbar;

            //Convert to slope / offset and return line.
            //NOTE: flipped X and Y to prevent vertical line issues. Assumes horrizontal line is not possible.

            return new Line(beta1, beta0);
        }
    }
}
