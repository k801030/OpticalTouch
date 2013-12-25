using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpticalTouch
{
    static class MainProgram
    {
        public static FullScreenPaint fs;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            USBProgram.Start(); // work as a thread
            //CalPoint.Start(); // calculate point
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            fs = new FullScreenPaint();
            Application.Run(fs);
            
        }
    }


}
