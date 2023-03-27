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
            string userInput = System.Console.ReadLine(); ;
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
                goingDownSeriesCounter++;
            if (isPalindrome)
                palindromeCounter++;
            if (isNumberDevideBy4)
                devidedBy4counter++;
        }
        PrintSummaryScreen(zeroCounter, onesCounter, devidedBy4counter, goingDownSeriesCounter, palindromeCounter);
    }
    public static bool CheckIfNumberIsBinary(string i_userInput)
    {
        foreach (char c in i_userInput)
        {
            if (c != '0' && c != '1')
                return false;

        }
        return true;
    }
    public static int ConvertBinaryStringToDecimalAndCountZEROandONES(string i_userInput, ref int i_zeroCounter, ref int i_onesCounter)
    {
        int result = 0;

        for (int i = 0; i < i_userInput.Length; i++)
        {
            int bit = i_userInput[i] - '0';
            if (bit == 0)
                i_zeroCounter++;
            else
                i_onesCounter++;
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
                prevDigit = currentDigit;
            else
                isGoingDown = false;
        }

        if (isGoingDown)
            return true;
        else
            return false;
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

        if (originalNumber == reversedNumber)
            return true;
        else
            return false;
    }
    public static void PrintSummaryScreen(int i_zerosCounter, int i_onesCounter, int i_devidedBy4counter, int i_goingDownSeriesCounter, int i_palindromeCounter)
    {
        System.Console.WriteLine("\nSummary:\n================\n");
        System.Console.WriteLine("Average number of zeros: " + i_zerosCounter / 3 + "\n");
        System.Console.WriteLine("Average number of ones: " + i_onesCounter / 3 + "\n");
        System.Console.WriteLine("Number of numbers that devides by 4: " + i_devidedBy4counter + "\n");
        System.Console.WriteLine("Number of numbers that are a going down series: " + i_goingDownSeriesCounter + "\n");
        System.Console.WriteLine("Number of numbers that are a palindrome: " + i_palindromeCounter + "\n");
        System.Console.WriteLine("================\n");

    }
    public static bool CheckIfNumberIsDevidedBy4(string i_userInput, int i_stringLength)
    {
        if (i_stringLength >= 2 && i_userInput.Substring(i_stringLength - 2) == "00")
            return true;
        else
            return false;
    }
}