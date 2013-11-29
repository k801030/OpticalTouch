using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OpticalTouch
{
    public partial class Form1 : Form
    {
        private Chart chart1;
        private Random random = new Random();
        private int pointIndex = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            chart1 = new RealtimeChart().GetChart;
            this.Controls.Add(chart1);
            this.ResumeLayout(false);
        }

        private void timerRealTimeData_Tick(object sender, EventArgs e)
        {
            // Define some variables
            int numberOfPointsInChart = 10;
            int numberOfPointsAfterRemoval = 10;
            
            // Simulate adding new data points
            int newX = pointIndex + 1;
            int newY = random.Next(0, 5000);

            chart1.Series[0].Points.AddXY(newX, newY);
            ++pointIndex;

            // Adjust Y & X axis scale
            chart1.ResetAutoValues();
            if (chart1.ChartAreas["Default"].AxisX.Maximum < pointIndex)
            {
                chart1.ChartAreas["Default"].AxisX.Maximum = pointIndex;
            }

            // Keep a constant number of points by removing them from the left
            while (chart1.Series[0].Points.Count > numberOfPointsInChart)
            {
                // Remove data points on the left side
                while (chart1.Series[0].Points.Count > numberOfPointsAfterRemoval)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                chart1.ChartAreas["Default"].AxisX.Minimum = pointIndex - numberOfPointsAfterRemoval;
                chart1.ChartAreas["Default"].AxisX.Maximum = chart1.ChartAreas["Default"].AxisX.Minimum + numberOfPointsInChart;
            }

            // Redraw chart
            chart1.Invalidate();
        }
    }
}
