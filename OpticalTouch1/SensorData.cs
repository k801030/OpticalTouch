using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalTouch
{
    class SensorData
    {
        static byte[,] data = new byte[2,500];

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
                data[column, row * 63 + j] = _data[i];

           
            }
        }

        public static byte[,] GetData()
        {
            return data;
        }

        public static int GetSingleData(int column, int x)
        {
            return data[column, x];
        }

       

    }
}
