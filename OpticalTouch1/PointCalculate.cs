using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OpticalTouch
{
    class PointCalculate
    {
        public static void Start()
        {
            Thread t1 = new Thread(ThreadProgram);
        }

        private static void ThreadProgram()
        {
            int[,] data = SensorData.GetNewData;


        }

        private static int[] calangle(int[] left, int[] right)
        {
            int L_left = 0;
            int L_right = 500;
            int R_left = 0;
            int R_right = 500;
            int threshold = 200; //define threshold
            int[] angle = new int[2];
            //angle[0] means left angle
            //angle[1] means right angle
            // Calculate left peak
            for (int i = 0; i < 499; i++)
            {
                if (left[i] - left[i + 1] >= threshold)
                {
                    L_left = i;
                    break;
                }
            }

            for (int i = 499; i >= 2; i++)
            {
                if (left[i] - left[i - 1] >= threshold)
                {
                    L_right = i;
                    break;
                }
            }

            angle[0] = (L_left + L_right) / 2;

            //

            //Calculate right peak

            for (int i = 0; i < 499; i++)
            {
                if (right[i] - right[i + 1] >= threshold)
                {
                    R_left = i;
                    break;
                }
            }

            for (int i = 499; i >= 2; i++)
            {
                if (right[i] - right[i - 1] >= threshold)
                {
                    R_right = i;
                    break;
                }
            }
            angle[1] = (R_left + R_right) / 2;
            //

            return angle;

        }

        private static int[] calpoint(int l_angle, int r_angle)
        {
            double cmtopixel = 40;//depend on each monitor
            double width = 34;//define the width of screen
            double l_theta = (l_angle * 90 / 500) * Math.PI / 180;
            double r_theta = (r_angle * 90 / 500) * Math.PI / 180;
            double ycm = width * Math.Tan((Math.PI / 2) - r_theta) / (Math.Tan((Math.PI / 2) - r_theta) + Math.Tan(l_theta));
            double xcm = ycm * Math.Tan(l_theta);
            Console.WriteLine(xcm);
            Console.WriteLine(ycm);
            int xpixel = Convert.ToInt32(xcm * cmtopixel);
            int ypixel = Convert.ToInt32(ycm * cmtopixel);
            int[] g = new int[2];
            g[0] = xpixel;
            g[1] = ypixel;
            return g;
        }
    }
}
