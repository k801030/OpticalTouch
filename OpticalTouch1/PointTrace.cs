using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OpticalTouch
{
    class PointTrace
    {
        static Stack<Point> TP = new Stack<Point>();
        static bool TouchDown = false;

        
        public static void Trace(){
            
            
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            // mouse control
            if (BoundPoint == null){
                //if(TouchDown == true)
                    //MainProgram.fs.MouseUp();
                TouchDown = false;
            }else{
                
                Point p = new Point();
                p.X = (BoundPoint[0].X + BoundPoint[1].X + BoundPoint[2].X + BoundPoint[3].X) / 4;
                p.Y = (BoundPoint[0].Y + BoundPoint[1].Y + BoundPoint[2].Y + BoundPoint[3].Y) / 4;

                TP.Push(p);
                if (TouchDown == false)
                {
                    //TouchDown = true;
                    //MainProgram.fs.MouseDown();
                }else { 
                    MainProgram.fs.MouseMove(p);
                }

            }


        }
    }
}
