using System;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            BinaryToDecimalAndStats();
        }
        public static void BinaryToDecimalAndStats()
        {
            int zeroCounter = 0, onesCounter = 0, devidedBy4counter = 0, goingDownSeriesCounter = 0, palindromeCounter = 0;
            Console.WriteLine("Please enter 3 binary numbers, 8 digits each.");
            Console.WriteLine("type each number and press ENTER to insert it");

            for (int i = 0; i < 3; i++)
            {
                GetStringAndCheckIfNumberIsBinary(out string userInput, out int stringLength, out bool isBinary);
                while (stringLength != 8 || !isBinary)
                {
                    Console.WriteLine("Your input is invalid, please try again");
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
        public static void GetStringAndCheckIfNumberIsBinary(out string o_UserInput, out int o_StringLength, out bool o_ReturnVal)
        {
            o_UserInput = System.Console.ReadLine();
            o_StringLength = o_UserInput.Length;
            o_ReturnVal = true;
            foreach (char c in o_UserInput)
            {
                if (c != '0' && c != '1')
                {
                    o_ReturnVal = false;
                }
            }
        }
        public static int ConvertBinaryStringToDecimalAndCountZEROandONES(string i_UserInput, ref int io_ZeroCounter, ref int io_OnesCounter)
        {
            int result = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                int bit = i_UserInput[i] - '0';
                if (bit == 0)
                {
                    io_ZeroCounter++;
                }
                else
                {
                    io_OnesCounter++;
                }
                result = (result << 1) | bit;
            }
            return result;
        }
        public static bool CheckIfNumberIsGoingDownSerias(int i_DecimalNumber)
        {
            bool isGoingDown = true;
            int prevDigit = i_DecimalNumber % 10;

            while (i_DecimalNumber > 0 && isGoingDown)
            {
                i_DecimalNumber = i_DecimalNumber / 10;
                int currentDigit = i_DecimalNumber % 10;

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
        public static bool CheckIfNumberIsPalindrome(int i_DecimalNumber)
        {
            int originalNumber = i_DecimalNumber;
            int reversedNumber = 0;

            while (i_DecimalNumber > 0)
            {
                int digit = i_DecimalNumber % 10;
                reversedNumber = reversedNumber * 10 + digit;
                i_DecimalNumber = i_DecimalNumber / 10;
            }

            return originalNumber == reversedNumber;
        }
        public static void PrintSummaryScreen(int i_ZerosCounter, int i_OnesCounter, int i_DevidedBy4counter, int i_GoingDownSeriesCounter, int i_PalindromeCounter)
        {
            Console.WriteLine("Summary:");
            Console.WriteLine("================");
            Console.WriteLine(string.Format(@"Average number of zeros: {0}
Average number of ones: {1}
Number of numbers that devides by 4: {2}
Number of numbers that are a going down series: {3}
Number of numbers that are a palindrome: {4}", i_ZerosCounter / 3, i_OnesCounter / 3, i_DevidedBy4counter, i_GoingDownSeriesCounter, i_PalindromeCounter));
            Console.WriteLine("================\n");
            Console.WriteLine("Press any key to exit\n");
            Console.ReadLine();

        }
        public static bool CheckIfNumberIsDevidedBy4(string i_UserInput, int i_StringLength)
        {
            return (i_StringLength >= 2 && i_UserInput.Substring(i_StringLength - 2) == "00");
        }
    }
}