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


        
        private 
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            // mouse control
            if(BoundPoint != null)
            {
                p = new Point();
                p.X = (BoundPoint[0].X + BoundPoint[1].X + BoundPoint[2].X + BoundPoint[3].X) / 4;
                p.Y = (BoundPoint[0].Y + BoundPoint[1].Y + BoundPoint[2].Y + BoundPoint[3].Y) / 4;
            }
    }
}
