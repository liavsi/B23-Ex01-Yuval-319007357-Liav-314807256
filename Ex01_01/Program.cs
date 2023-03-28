public class Program
{
    public static void Main()
    {
        BinaryToDecimalAndStats();
    }
    public static void BinaryToDecimalAndStats()
    {
        int zeroCounter = 0, onesCounter = 0, devidedBy4counter = 0, goingDownSeriesCounter = 0, palindromeCounter = 0;

        for (int i = 0; i < 3; i++)
        {
            System.Console.WriteLine("\nPlease enter 3 binary numbers, 8 digits each.\ntype each number and press ENTER to insert it\n");
            string userInput = System.Console.ReadLine(); 
            int stringLength = userInput.Length;
            bool isBinary = CheckIfNumberIsBinary(userInput);

            while (stringLength != 8 || !isBinary)
            {
                System.Console.WriteLine("\nYour input is invalid, please try again\n");
                userInput = System.Console.ReadLine();
                stringLength = userInput.Length;
                isBinary = CheckIfNumberIsBinary(userInput);
            }
            bool isNumberDevideBy4 = CheckIfNumberIsDevidedBy4(userInput, stringLength);
            int decimalNumber = ConvertBinaryStringToDecimalAndCountZEROandONES(userInput, ref zeroCounter, ref onesCounter);
            bool isGoingDownSeries = CheckIfNumberIsGoingDownSerias(decimalNumber);
            bool isPalindrome = CheckIfNumberIsPalindrome(decimalNumber);
            if (isGoingDownSeries)
                {
                    goingDownSeriesCounter++;
                }
                
            if (isPalindrome)
                {
                    palindromeCounter++;
                }
                
            if (isNumberDevideBy4)
                {
                    devidedBy4counter++;
                }
               
        }
        PrintSummaryScreen(zeroCounter, onesCounter, devidedBy4counter, goingDownSeriesCounter, palindromeCounter);
    }
    public static bool CheckIfNumberIsBinary(string i_userInput)
    {
        bool returnVal = true;
        foreach (char c in i_userInput)
        {
            if (c != '0' && c != '1')
            {
                return !returnVal;
            }
        }
        return returnVal;
    }
    public static int ConvertBinaryStringToDecimalAndCountZEROandONES(string i_userInput, ref int io_zeroCounter, ref int io_onesCounter)
    {
        int result = 0;

        for (int i = 0; i < i_userInput.Length; i++)
        {
            int bit = i_userInput[i] - '0';
            if (bit == 0)
            {
                io_zeroCounter++;
            }
            else
            {
                io_onesCounter++;
            }
            result = (result << 1) | bit;
        }
        return result;
    }
    public static bool CheckIfNumberIsGoingDownSerias(int i_decimalNumber)
    {
        bool isGoingDown = true;
        int prevDigit = i_decimalNumber % 10;

        while (i_decimalNumber > 0 && isGoingDown)
        {
            i_decimalNumber = i_decimalNumber / 10;
            int currentDigit = i_decimalNumber % 10;

            if (currentDigit < prevDigit)
            {
                prevDigit = currentDigit;
            }
            else
            {
                isGoingDown = false;
            }
        }

        return isGoingDown;

    }
    public static bool CheckIfNumberIsPalindrome(int i_decimalNumber)
    {
        int originalNumber = i_decimalNumber;
        int reversedNumber = 0;

        while (i_decimalNumber > 0)
        {
            int digit = i_decimalNumber % 10;
            reversedNumber = reversedNumber * 10 + digit;
            i_decimalNumber = i_decimalNumber / 10;
        }

        return originalNumber == reversedNumber;
    }
    public static void PrintSummaryScreen(int i_zerosCounter, int i_onesCounter, int i_devidedBy4counter, int i_goingDownSeriesCounter, int i_palindromeCounter)
    {
        System.Console.WriteLine("\nSummary:\n================\n");
        System.Console.WriteLine(string.Format("Average number of zeros: {0}\nAverage number of ones: {1}\nNumber of numbers that devides by 4: {2}\nNumber of numbers that are a going down series: {3}\nNumber of numbers that are a palindrome: {4}\n", i_zerosCounter / 3, i_onesCounter / 3, i_devidedBy4counter, i_goingDownSeriesCounter, i_palindromeCounter));
        System.Console.WriteLine("================\n");

    }
    public static bool CheckIfNumberIsDevidedBy4(string i_userInput, int i_stringLength)
    {
        return(i_stringLength >= 2 && i_userInput.Substring(i_stringLength - 2) == "00");
    }
}