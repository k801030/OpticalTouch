using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


using USBHIDDRIVER;


namespace OpticalTouch
{
    class USBProgram
    {
        static USBInterface usb;
        static string vid = "vid_04d8";
        static string pid = "pid_003f";

        public static void Start()
        {
            usb = new USBInterface(vid, pid);
            Console.WriteLine("USB Connection: "+usb.Connect());


            usb.startRead();
            
            
            /*
            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("usb buffer: " + USBInterface.usbBuffer.Count);

            }


            
            int count = USBInterface.usbBuffer.Count;
            int start = 0;
            for(int i=0;i<8;i++)

                    byte[] buf = (byte[])USBInterface.usbBuffer[start];
                int bufLength = buf.Length;
                count++;
                
                
            }
            */

            Thread.Sleep(500);
            byte[,] data = SensorData.GetData();
            for (int i = 0; i < 2; i++) 
            { 
                for(int j=0;j<500;j++)
                {
                    Console.Write(data[i,j]+" ");
                }
                Console.WriteLine();
            }
                    

            //usb.stopRead();


            //MyPause();
        }
        private static void startRead()
        {
            
            
            
            if (USBInterface.usbBuffer ==null)
            {
                Console.WriteLine("Get no data from usb.");
            }
            /*int count = USBInterface.usbBuffer.Count;
            foreach(byte buffer in USBInterface.usbBuffer)
            {
                
                Console.WriteLine(USBInterface.usbBuffer);
            }*/
   
        }

        private static void MyPause()
        {
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }
    }
}
