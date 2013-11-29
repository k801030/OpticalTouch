using System.Windows.Forms.DataVisualization.Charting;

namespace OpticalTouch
{
    class RealtimeChart
    {
        private Chart chart = null;
        private int chartWidth = 720;
        private int chartHeight = 480;
        private string nameAxisX = "X";
        private string nameAxisY = "Y";

        public RealtimeChart()
        {
            chart = new Chart();

            ChartArea ctArea = new ChartArea();
            chart.ChartAreas.Add("area2");
            Legend legend = new Legend();
            Series series = new Series();  // data and attributes of series
            
            chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
            chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
            chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chart.BorderlineWidth = 2;
            chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chart.Location = new System.Drawing.Point(10, 10);
            chart.Name = "chart1";
            chart.Size = new System.Drawing.Size(chartWidth, chartHeight);
            chart.TabIndex = 1;
            chart.Dock = System.Windows.Forms.DockStyle.Fill;

 
            ctArea.AxisX.IsLabelAutoFit = false;
            ctArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            ctArea.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            ctArea.AxisX.Title = nameAxisX;
            ctArea.AxisY.IsLabelAutoFit = false;
            ctArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            ctArea.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea.AxisY.Maximum = 5000D;
            ctArea.AxisY.Minimum = 0D;
            ctArea.AxisY.Title = nameAxisY;
            ctArea.BackColor = System.Drawing.Color.OldLace;
            ctArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            ctArea.BackSecondaryColor = System.Drawing.Color.White;
            ctArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ctArea.Name = "Default";
            ctArea.ShadowColor = System.Drawing.Color.Transparent;
            chart.ChartAreas.Add(ctArea);

            legend.BackColor = System.Drawing.Color.Transparent;
            legend.Enabled = false;
            legend.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend.IsTextAutoFit = false;
            legend.Name = "Default";
            chart.Legends.Add(legend);

            series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series.ChartArea = "Default";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series.Legend = "Default";
            series.Name = "Default";
            chart.Series.Add(series);
        }

        public Chart GetChart
        {
            get { return chart; }
        }
    }
}
