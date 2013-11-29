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
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(formWidth, formHeight);
            this.SuspendLayout();
            chart = new RealtimeChart().GetChart;
            this.Controls.Add(chart);
            this.ResumeLayout(false);
        }

        private void timerRealTimeData_Tick(object sender, EventArgs e)
        {
            // Define some variables
            int numberOfPointsInChart = 10;
            int numberOfPointsAfterRemoval = 10;

            // clear all points
            chart.Series[0].Points.Clear();
            // Simulate adding new data points
            int newY = random.Next(0, 5000);
            for(int i=0;i<pointIndex;i++)
                chart.Series[0].Points.AddXY(i, newY);




            


            // Redraw chart
            chart.Invalidate();
        }
    }
}
