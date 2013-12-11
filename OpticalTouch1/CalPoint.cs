using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Drawing;

namespace OpticalTouch
{
    class CalPoint
    {
       
        public static Point[] BoundPoint;
        private static int[,] data = new int[2,500];

        public static void Start()
        {
            Thread t1 = new Thread(ThreadProgram);
            t1.Start();
        }

        private static void ThreadProgram()
        {
            data = SensorData.GetNewData;
            
            while (true)
            {
                BoundPoint = FindBoundPoint();  // 2x2 matrix
            }
            

        }


        public static Point[] FindBoundPoint()
        {
            const int thresholdL1 = 200;  // for sensing object
            const int thresholdL2 = 230;  // for finding boundary
            bool findPoint = false;

            int[,] BoundAngle = new int[2 , 2];
            Point[] BoundPoint = new Point[4];

            //data = SensorData.GetNewData;
            int[,] _data;
            _data = SensorData.GetNewData;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++)
                    data[i, j] = _data[i, j];


            for(int i=0;i<2;i++)  //side
                for(int j=0;j<500;j++) //angle
                {
                    if (data[i, j] < thresholdL1)
                    {
                        findPoint = true;
                        for (int k = 0; k < 500; k++)
                        {
                            if(data[i,j-k] > thresholdL2 || j - k ==0)
                            {
                                BoundAngle[i, 0] = j - k;
                                break;
                            }
                        }
                        for (int k = 0; j < 500; k++)
                        {
                            if (data[i,j+k] > thresholdL2 || j + k == 499)
                            {
                                BoundAngle[i, 1] = j + k;
                                break;
                            }
                        }

                    }
                }
            
            BoundPoint[0] = calpoint(BoundAngle[0, 0], BoundAngle[1, 0]);
            BoundPoint[1] = calpoint(BoundAngle[0, 1], BoundAngle[1, 0]);
            BoundPoint[2] = calpoint(BoundAngle[0, 1], BoundAngle[1, 1]);
            BoundPoint[3] = calpoint(BoundAngle[0, 0], BoundAngle[1, 1]);

            if (findPoint)
            {
                return BoundPoint;
            }
            else 
            { 
                return null;
            }

        }

        private static Point calpoint(int l_angle, int r_angle)
        {
            //depend on each monitor  ratio = resolution / length(cm)
            const double Xratio = 33.3;
            const double Yratio = 46.15;//55.813;
            double width = 49;//define the width of screen

            r_angle += 15; // offset

            double l_theta = (l_angle * 90 / 500) * Math.PI / 180;
            double r_theta = (r_angle * 90 / 500) * Math.PI / 180;
            
            double xcm = width * Math.Tan((Math.PI / 2) - r_theta) / (Math.Tan((Math.PI / 2) - r_theta) + Math.Tan(l_theta));
            double ycm = xcm * Math.Tan(l_theta);
            

            xcm -= 1; 
            ycm -= 1; 
            int xpixel = Convert.ToInt32(xcm * Xratio);
            int ypixel = Convert.ToInt32(ycm * Yratio);
            
                
            
            //  there are some offset
          // ypixel -= 160;
          // xpixel -= 50;

            Point p = new Point();
            p.X = xpixel;
            p.Y = ypixel; 
            return p;
        }
    }
}
