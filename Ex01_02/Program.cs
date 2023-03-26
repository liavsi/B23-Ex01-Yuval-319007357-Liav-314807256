using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        static public void Main()
        {
            printDiamond(5, 1);
        }

        static public void printDiamond(int i_LongestRow, int i_CurrentRow)
        {
            if (i_LongestRow <= i_CurrentRow)
            {
                printRowOfDiamond(i_LongestRow, i_CurrentRow);
            }
            else
            {
                printRowOfDiamond(i_LongestRow, i_CurrentRow);
                printDiamond(i_LongestRow, i_CurrentRow + 1);
                printRowOfDiamond(i_LongestRow, i_CurrentRow);
            }
        }

        static public void printRowOfDiamond(int i_LongestRow, int i_RowToPrint)
        {
            int numberOfSpaces = i_LongestRow - i_RowToPrint;
            int numberOfStars = i_RowToPrint * 2 - 1;
            for (int i = 0; i < numberOfSpaces; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < numberOfStars; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
