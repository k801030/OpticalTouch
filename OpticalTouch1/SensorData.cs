using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalTouch
{
    class SensorData
    {
        static int[,] rawData = new int[2, 500]; // original data from sensor
        static int[,] newData = new int[2, 500]; // data after processing
        static int[,] bgData = new int[2, 500];  // for background substraction
        static bool getBGBool = false;  // if we ever or not get background
        static bool[,] dataCheck = new bool[2,8]; // for id check

        //check the data is all received.
        /*struct DataCheck
        {
            public byte id;
            public bool vaild;
        }
        List<DataCheck> dataCheck = new List<DataCheck>();

        public static void init()
        {
            DataCheck[] dc = new DataCheck[16];

        }*/


        public static void RetrieveData(byte[] _data)
        {
            
            
            byte id = _data[1];  // identify the set of data
            int column = id / 10 -1;
            int row = id % 10;
            int i, j;
            for (i = 2; i < 65; i++) // usable data from sensor
            {
                j = i - 2; //offset

                if (row == 7 && i >= 61)  // these are useless bits
                    continue;
                if (_data[i] < 20)   // these are error received bits
                    continue;
                rawData[column, row * 63 + j] = _data[i];
                
            }
            //newData = rawData;    this will make error wave

            
            

            

            dataCheck[column, row] = true;

            //Console.WriteLine("~~ (" + column + " " + row + ") "+dataCheck[column,row] );


            if(AllDataReceive())
            {
                if (getBGBool == false)
                { // not get yet
                    getBackground();
                }
                else
                {
                    SubBackground();
                }

                SubmitToNewData();

                MainProgram.fs.MouseMove();

                /*
                for ( i = 0; i < 2; i++) 
                { 
                    for ( j = 0; j < 500; j++)
                    {
                        Console.Write(newData[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                 */
            }
        }

        private static bool AllDataReceive()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (dataCheck[i, j] == false)
                        return false;
                        
                }

            //reset data check
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 8; j++)
                    dataCheck[i, j] = false;
            return true;
        }

        private static void SubmitToNewData()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++)
                    newData[i, j] = rawData[i, j];
            
        }

        public static int[,] GetNewData
        {
           get {return newData;}
        }

        public static int[,] GetRawData
        {
           get {return rawData;}
        }

 

        /// <summary>
        /// Some data received are error
        /// </summary>
        private static void reduceNoise()
        {

        }

        /// <summary>
        ///  To substract the initial background
        /// </summary>
        private static void SubBackground()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++)
                    rawData[i, j] = (255 + rawData[i, j] - bgData[i, j]);
                    
        }

        public static void getBackground()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++)
                    bgData[i,j] = rawData[i,j];
            getBGBool = true;

        }

        public static void returnData()
        {

        }

    }
}
