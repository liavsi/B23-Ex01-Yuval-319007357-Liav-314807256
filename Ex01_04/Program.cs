using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            StringsAnalysis();
        }
        public static void StringsAnalysis()
        {
            Console.WriteLine(string.Format("Please enter a {0} characters word of english letters only or numbers only.", 6));
            GetAndCheckUserInput(out string userInput, out bool isMixedLettersAndNumbers);
            while (isMixedLettersAndNumbers)
            {
                Console.WriteLine("{0} is an invalid input\nPlease try again", userInput);
                GetAndCheckUserInput(out userInput, out isMixedLettersAndNumbers);
            }
            int inputNumber = CheckIfStringIsPalindromeAndANumber(out bool isANumber, userInput, out bool isPalindrom);
            bool isDevidedBy3 = true;
            int uppercaseCount = 0;
            if (isANumber)
            {
                isDevidedBy3 = inputNumber % 3 == 0;
            }
            else
            {
                uppercaseCount = CountUpperCaseLettersInString(userInput);
            }

            SummaryScreen(isPalindrom, isANumber, isDevidedBy3, uppercaseCount);
        }
        public static void GetAndCheckUserInput(out string o_UserInput, out bool o_IsMixedLettersAndNumbers)
        {
            bool containsLetter = false;
            bool containsDigit = false;
            o_UserInput = Console.ReadLine();
            foreach (char c in o_UserInput)
            {
                if (char.IsLetter(c))
                {
                    containsLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    containsDigit = true;
                }
            }

            o_IsMixedLettersAndNumbers = containsLetter && containsDigit;
        }
        public static int CheckIfStringIsPalindromeAndANumber(out bool o_IsNumber, string i_UserInput, out bool o_IsPalindrom)
        {
            int startIndex = 0, endIndex = i_UserInput.Length - 1, userInputInt = 0;
            o_IsNumber = false;
            o_IsPalindrom = IsPalindrome(i_UserInput, startIndex, endIndex);

            if (char.IsDigit(i_UserInput[startIndex]))
            {
                o_IsNumber = true;
                userInputInt = int.Parse(i_UserInput);
            }

            return userInputInt;
        }
        public static bool IsPalindrome(string i_String, int i_Start, int i_End)
        {
            // recursive function thus we have more than one return line
            if (i_Start >= i_End)
            {
                return true; 
            }

            if (i_String[i_Start] != i_String[i_End])
            {
                return false;
            }

            return IsPalindrome(i_String, i_Start + 1, i_End - 1);
        }
        public static int CountUpperCaseLettersInString(string i_UserInput)
        {
            int uppercaseCount = 0;

            foreach (char c in i_UserInput)
            {
                if (char.IsUpper(c))
                {
                    uppercaseCount++;
                }
            }

            return uppercaseCount;
        }
        public static void SummaryScreen(bool i_IsPalindrom, bool i_IsANumberBool, bool i_IsDevidedBy3, int i_UppercaseCount)
        {
            Console.WriteLine("Summary:");
            Console.WriteLine("================");
            Console.WriteLine(string.Format(@"1. The string is{0}a palindrome
2. The string is{1}a number", i_IsPalindrom ? " " : " not ", i_IsANumberBool ? " " : " not "));
            if (i_IsANumberBool)
            {
                Console.WriteLine(string.Format("3. {0}", i_IsDevidedBy3 ? "The number devides by 3" : " The number doesn't devides by 3 "));
            }
            else
            {
                Console.WriteLine(string.Format("3. The number of upper-case letters is: {0}", i_UppercaseCount));
            }

            Console.WriteLine("================");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
