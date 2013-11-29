using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


using USBHIDDRIVER;


namespace OpticalTouch
{
    class Program2
    {
        static USBInterface usb;
        static string vid = "vid_04d8";
        static string pid = "pid_003f";

        static void program2()
        {
            usb = new USBInterface(vid, pid);
            Console.WriteLine("USB Connection: "+usb.Connect());


            usb.startRead();
            Thread.Sleep(5);

            for (int i = 0; i < 8; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("usb buffer: " + USBInterface.usbBuffer.Count);

            }

            int count = USBInterface.usbBuffer.Count;
            for (int i = 0; i < count;i++ )
            {
                byte[] buf = (byte[])USBInterface.usbBuffer[i];
                int bufLength = buf.Length;
                
                for (int j = 0; j < bufLength;j++ )
                    Console.Write(buf[j] + " ");
                Console.WriteLine();
            }

            
            usb.stopRead();


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
