using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Threading;

namespace OpticalTouch
{
    

    public partial class FullScreenPaint : Form
    {
        byte MOUSEEVENTF_LEFTDOWN = 0x0002;
        byte MOUSEEVENTF_LEFTUP = 0x0004;
        int count = 0;
        static Label lab, lab2;
        static Point p;
        Graphics g;
        public FullScreenPaint()
        {
            InitializeComponent();

            lab = new Label();
            this.Controls.Add(lab);

            g = this.CreateGraphics();
        }

        public static void setText(double a, double b)
        {　
            string text ;
            text = string.Format("{0:F1}", a) + " ， " + string.Format("{0:F1}", b);

            lab.Text = Convert.ToString(text);
        }


        private void MyOnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Escape)
            {
                this.Close();
            }else if(e.KeyChar == (char)Keys.Space)
            {
                g.Clear(Color.White);
            }

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            

            //e.Graphics.FillRectangle(blueBrush, p.X, p.Y, 10, 10);
            
        }

        private void setMousePosition(Point point)
        {


            
            Cursor.Position = point; 
            
        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private static bool MouseStatus = false;
        private const bool UP = true;
        private const bool DOWN = false;
        public void MouseControl()
        {
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            Point p = new Point();
            if (BoundPoint != null) { 
            
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
                /*
               
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
                */

                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(blueBrush, p.X, p.Y, 10, 10);
            }else {
                if (MouseStatus == DOWN) { 
                    MouseUp();
                    MouseStatus = UP;
                }
            }


                
            //this.Invalidate();
        }

        private void MouseMove(Point p)
        {
            setMousePosition(p);
        }
        private void MouseDown(Point p)
        {
            Console.WriteLine("DOWN");
            setMousePosition(p);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(100);
        }
 
        private void MouseUp()
        {
            Console.WriteLine("UP");
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(100);
        }

        private void Print()
        {
            Console.WriteLine("//////////////////");
            Console.WriteLine(p.X + " " + p.Y);
            int[,] _data;
            _data = SensorData.GetNewData;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 500; j++)
                    Console.Write(_data[i, j] + ", ");
                Console.WriteLine();
            }

           
        }

        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
    }
}
