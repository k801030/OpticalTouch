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
        static int[,] data;
        public static void Start()
        {
            Thread t1 = new Thread(ThreadProgram);
        }

        private static void ThreadProgram()
        {
            data = SensorData.GetNewData;


        }

        private static int[] calangle()
        {

            int threshold = 200; //pixel value
            int[] angle = new int[2];
            //angle[0] means left angle
            //angle[1] means right angle
            // Calculate left peak
            for (int i = 0; i < 500; i++)
            {
                if (data[0, i] < threshold) 
                { 
                    for (int j = 0; j < 500; j++)
                    {
                        if (data[1, j] < threshold)
                        {
                            calpoint(i, j);
                        }
                    }
                }
            }



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
