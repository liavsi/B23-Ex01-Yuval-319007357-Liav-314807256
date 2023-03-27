namespace Ex01_02
{
    public class Program
    {
        static public void Main()
        {
            PrintDiamond(5, 1);
        }

        static public void PrintDiamond(int i_LongestRow, int i_CurrentRow)
        {
            if (i_LongestRow <= i_CurrentRow)
            {
                PrintRowOfDiamond(i_LongestRow, i_CurrentRow);
            }
            else
            {
                PrintRowOfDiamond(i_LongestRow, i_CurrentRow);
                PrintDiamond(i_LongestRow, i_CurrentRow + 1);
                PrintRowOfDiamond(i_LongestRow, i_CurrentRow);
            }
        }

        static public void PrintRowOfDiamond(int i_LongestRow, int i_RowToPrint)
        {
            int numberOfSpaces = i_LongestRow - i_RowToPrint;
            int numberOfStars = i_RowToPrint * 2 - 1;

            for (int i = 0; i < numberOfSpaces; i++)
            {
                System.Console.Write(" ");
            }

            for (int i = 0; i < numberOfStars; i++)
            {
                System.Console.Write("*");
            }

            System.Console.WriteLine();
        }
    }
}
