using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OpticalTouch
{
    public partial class Form1 : Form
    {
        private Chart chart;
        private Random random = new Random();
        private int pointIndex = 50;
        
        private const int formHeight = 480;
        private const int formWidth = 720;

        public Form1()
        {
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closed);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Size = new System.Drawing.Size(formWidth, formHeight);
            this.SuspendLayout();
            chart = new RealtimeChart().GetChart;
            this.Controls.Add(chart);
            this.Controls.Add(chart);
            this.ResumeLayout(false);
        }

        private void timerRealTimeData_Tick(object sender, EventArgs e)
        {
            

            // clear all points
            chart.Series[0].Points.Clear();

            int[,] data = SensorData.GetNewData;
            for(int i=0;i<500;i++)
                chart.Series[0].Points.AddXY(i, data[1,i]);
            // Redraw chart
            chart.Invalidate();
        }



        // when close, exit the program
        private void Form_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);          
        }
    }
}
