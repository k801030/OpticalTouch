using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
namespace OpticalTouch
{
    static class MainProgram
    {

        public static FullScreenPaint fs;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            USBProgram.Start(); // work as a thread
            
            
        }




        private static void setMousePosition(Point point)
        {
            Cursor.Position = point;
        }

        static bool MouseStatus = false;
        const bool UP = true;
        const bool DOWN = false;
        const byte MOUSEEVENTF_LEFTDOWN = 0x0002;
        const byte MOUSEEVENTF_LEFTUP = 0x0004;
        public static void MouseControl()
        {
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            Point p = new Point();
            if (BoundPoint != null)
            {

                p.X = (BoundPoint[0].X + BoundPoint[1].X + BoundPoint[2].X + BoundPoint[3].X) / 4;
                p.Y = (BoundPoint[0].Y + BoundPoint[1].Y + BoundPoint[2].Y + BoundPoint[3].Y) / 4;

                if (MouseStatus == DOWN)
                {
                    MouseMove(p);
                }
                else
                {
                    MouseDown(p);
                    MouseStatus = DOWN;
                }

            }
            else
            {
                if (MouseStatus == DOWN)
                {
                    MouseUp();
                    MouseStatus = UP;
                }
            }
        }

        private static void MouseMove(Point p)
        {
            setMousePosition(p);
        }
        private static void MouseDown(Point p)
        {
            Console.WriteLine("DOWN");
            setMousePosition(p);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(100);
        }

        private static void MouseUp()
        {
            Console.WriteLine("UP");
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(100);
        }


        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
    }


}
