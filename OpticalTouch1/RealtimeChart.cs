using System.Windows.Forms.DataVisualization.Charting;
namespace test2
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
            Legend legend = new Legend();
            Series series = new Series();  // data and attributes of series


        }

        public Chart GetChart
        {
            get { return chart; }
        }
    }
}
