using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            while(true)
            {
                int heightOfDiamond = UsersInputHeight();
                Ex01_02.Program.PrintDiamond(heightOfDiamond, 1);
            }
        }
   
        public static int UsersInputHeight()
        {
            int defaultHeight = 9;
            string invalidInputMessage = string.Format("height must be a positive value!\ndefault value {0} will be printed", defaultHeight);

            Console.WriteLine("Please enter the height of the diamond:(then press enter) ");
            int inputHeight = int.Parse(Console.ReadLine());
            if (inputHeight < 0)
            {
                Console.WriteLine(invalidInputMessage);
                inputHeight = defaultHeight;
            }

            int retVal = (inputHeight / 2) + 1;

            return retVal;
        }
    }
}
