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


namespace OpticalTouch
{
    public partial class FullScreenPaint : Form
    {
        public FullScreenPaint()
        {
            InitializeComponent();
            
        }

        private void MyOnKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Escape)
            {
                this.Close();
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush blueBrush = new SolidBrush(Color.Gray);
            Point[] BoundPoint = CalPoint.FindBoundPoint();
            for (int i = 0; i < 4; i++)
            {
                //Console.WriteLine(BoundPoint[i].X+" "+BoundPoint[i].Y);
                
                e.Graphics.FillPolygon(blueBrush, BoundPoint);
                

            }

 
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            
            this.Invalidate();
        }
    }
}
