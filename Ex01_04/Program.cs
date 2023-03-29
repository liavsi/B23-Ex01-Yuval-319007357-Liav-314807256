using System;
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
            while(isMixedLettersAndNumbers)
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
        public static void GetAndCheckUserInput(out string o_userInput, out bool o_isMixedLettersAndNumbers)
        {
            bool containsLetter = false;
            bool containsDigit = false;
            o_userInput = Console.ReadLine();
            foreach (char c in o_userInput)
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
            o_isMixedLettersAndNumbers = containsLetter && containsDigit;
        }
        public static int CheckIfStringIsPalindromeAndANumber(out bool o_isANumber, string i_userInput, out bool o_isPalindrom)
        {
            int startIndex = 0, endIndex = i_userInput.Length-1;
            o_isANumber = false;
            o_isPalindrom = IsPalindrome(i_userInput, startIndex, endIndex);

            if (char.IsDigit(i_userInput[startIndex]))
            {
                    o_isANumber = true;
                    return System.Convert.ToInt32(i_userInput);
            }
            return 0;
            
        }
        public static bool IsPalindrome(string i_string, int i_start, int i_end)
        {
            if (i_start >= i_end)
            {
                return true;
            }

            if (i_string[i_start] != i_string[i_end])
            {
                return false;
            }

            return IsPalindrome(i_string, i_start + 1, i_end - 1);
        }
      public static int CountUpperCaseLettersInString(string i_userInput)
      {
        int uppercaseCount = 0;

        foreach (char c in i_userInput)
        {
            if (char.IsUpper(c))
            {
                uppercaseCount++;
            }
        }
        return uppercaseCount;
      }
    public static void SummaryScreen(bool i_isPalindrom, bool i_isANumberBool, bool i_isDevidedBy3, int i_uppercaseCount)
    {
        Console.WriteLine("Summary:");
        Console.WriteLine("================");
        Console.WriteLine(string.Format(@"1. The string is{0}a palindrome
2. The string is{1}a number", i_isPalindrom?" ":" not ", i_isANumberBool? " ": " not "));
        if(i_isANumberBool)
        {
            Console.WriteLine(string.Format("3. {0}", i_isDevidedBy3 ? "The number devides by 3" : " The number doesn't devides by 3 "));
        }
        else
        {
           Console.WriteLine(string.Format("3. The number of upper-case letters is: {0}", i_uppercaseCount));
        }
        Console.WriteLine("================");
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
}

