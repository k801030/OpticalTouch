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

namespace OpticalTouch
{
    

    public partial class FullScreenPaint : Form
    {
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
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            // mouse control
            if (BoundPoint != null)
            {
                p = new Point();
                p.X = (BoundPoint[0].X + BoundPoint[1].X + BoundPoint[2].X + BoundPoint[3].X) / 4;
                p.Y = (BoundPoint[0].Y + BoundPoint[1].Y + BoundPoint[2].Y + BoundPoint[3].Y) / 4;
                setMousePosition(p);
                /*
                byte MOUSEEVENTF_LEFTDOWN = 0x0002;
                byte MOUSEEVENTF_LEFTUP = 0x0004;
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
                */

                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(blueBrush, p.X, p.Y, 10, 10);


                Console.WriteLine(p.X + " " + p.Y);
                
                    
            }


            //this.Invalidate();
        }

        [DllImport("User32")]
        public extern static void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);
    }
}
