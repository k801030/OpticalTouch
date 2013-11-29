using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OpticalTouch
{
    public partial class Form1 : Form
    {
        private Chart chart;
        private Random random = new Random();
        private int pointIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            
        }
    }
}
