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

        const int intensityMin = 0;
        const int intensityMax = 255;
        const int pixelMin = 0;
        const int pixelMax = 500;

        public RealtimeChart()
        {
            chart = new Chart();

            ChartArea ctArea1 = new ChartArea("1");
            Legend legend = new Legend();
            Series seriesL = new Series("left");  // data and attributes of series
            Series seriesR = new Series("right");
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

 
            ctArea1.AxisX.IsLabelAutoFit = false;
            ctArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            ctArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            ctArea1.AxisX.Maximum = pixelMax;
            ctArea1.AxisX.Minimum = pixelMin;
            ctArea1.AxisX.Title = nameAxisX;

            ctArea1.AxisY.IsLabelAutoFit = false;
            ctArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            ctArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisY.Maximum = intensityMax;
            ctArea1.AxisY.Minimum = intensityMin;
            ctArea1.AxisY.Title = nameAxisY;

            ctArea1.BackColor = System.Drawing.Color.OldLace;
            ctArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            ctArea1.BackSecondaryColor = System.Drawing.Color.White;
            ctArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ctArea1.Name = "Default";
            ctArea1.ShadowColor = System.Drawing.Color.Transparent;
            chart.ChartAreas.Add(ctArea1);


            ctArea1.AxisX.IsLabelAutoFit = false;
            ctArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            ctArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            ctArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            ctArea1.AxisX.Maximum = pixelMax;
            ctArea1.AxisX.Minimum = pixelMin;
            ctArea1.AxisX.Title = nameAxisX;

           

            legend.BackColor = System.Drawing.Color.Transparent;
            legend.Enabled = false;
            legend.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend.IsTextAutoFit = false;
            legend.Name = "Default";
            chart.Legends.Add(legend);

            seriesL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            seriesL.ChartArea = "Default";
            seriesL.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesL.Legend = "Default";
            seriesL.Name = "Default";
            chart.Series.Add(seriesL);

           
        }

        public Chart GetChart
        {
            get { return chart; }
        }
    }
}
