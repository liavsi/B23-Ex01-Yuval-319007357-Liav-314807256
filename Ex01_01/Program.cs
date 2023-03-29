public class Program
{
    public static void Main()
    {
        BinaryToDecimalAndStats();
    }
    public static void BinaryToDecimalAndStats()
    {
        int zeroCounter = 0, onesCounter = 0, devidedBy4counter = 0, goingDownSeriesCounter = 0, palindromeCounter = 0;
        System.Console.WriteLine("Please enter 3 binary numbers, 8 digits each.");
        System.Console.WriteLine("type each number and press ENTER to insert it");
        
        for (int i = 0; i < 3; i++)
        { 
            GetStringAndCheckIfNumberIsBinary(out string userInput, out int stringLength, out bool isBinary);
            while (stringLength != 8 || !isBinary)
            {
                System.Console.WriteLine("Your input is invalid, please try again");
                GetStringAndCheckIfNumberIsBinary(out userInput, out stringLength, out isBinary);
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
    public static void GetStringAndCheckIfNumberIsBinary(out string o_userInput, out int o_stringLength, out bool o_returnVal)
    {
        o_userInput = System.Console.ReadLine();
        o_stringLength = o_userInput.Length;
        o_returnVal = true;
        foreach (char c in o_userInput)
        {
            if (c != '0' && c != '1')
            {
                o_returnVal = false;
            }
        }
        
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
        System.Console.WriteLine("Summary:");
        System.Console.WriteLine("================");
        System.Console.WriteLine(string.Format(@"Average number of zeros: {0}
Average number of ones: {1}
Number of numbers that devides by 4: {2}
Number of numbers that are a going down series: {3}
Number of numbers that are a palindrome: {4}", i_zerosCounter / 3, i_onesCounter / 3, i_devidedBy4counter, i_goingDownSeriesCounter, i_palindromeCounter));
        System.Console.WriteLine("================\n");
        System.Console.WriteLine("Press any key to exit\n");
        System.Console.ReadLine();

    }
    public static bool CheckIfNumberIsDevidedBy4(string i_userInput, int i_stringLength)
    {
        return(i_stringLength >= 2 && i_userInput.Substring(i_stringLength - 2) == "00");
    }
}