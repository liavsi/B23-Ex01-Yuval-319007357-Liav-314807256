
    public class Program
    {
        public static void Main()
        {
            StringsAnalysis();
        }
        public static void StringsAnalysis()
        {
            System.Console.WriteLine(string.Format("Please enter a {0} characters word of english letters only or numbers only.\n(please use capital letters only or lower-case letters only per word)", 6));
            string userInput = System.Console.ReadLine();
            bool isMixedLettersAndNumbers = CheckUserInput(userInput);
            while(isMixedLettersAndNumbers)
            {
                System.Console.WriteLine("{0} is an invalid input\nPlease try again", userInput);
                userInput = System.Console.ReadLine();
                isMixedLettersAndNumbers = CheckUserInput(userInput);
            }
            System.Collections.Generic.KeyValuePair<bool, int> isANumberPair = new System.Collections.Generic.KeyValuePair<bool, int>(false, 0);
            bool isPalindrom = CheckIfStringIsPalindrome(ref isANumberPair, userInput);
            bool isDevidedBy3 = true;
            int uppercaseCount = 0; 
            if (isANumberPair.Key)
            {
                 isDevidedBy3 = isANumberPair.Value % 3 == 0;
            }
            else
            {
                 uppercaseCount = CountUpperCaseLettersInString(userInput);
            }
            SummaryScreen(isPalindrom, isANumberPair.Key, isDevidedBy3, uppercaseCount);
        }
        public static bool CheckUserInput(string i_userInput)
        {
            bool containsLetter = false;
            bool containsDigit = false;

            foreach (char c in i_userInput)
            {
                if (System.Char.IsLetter(c))
                {
                    containsLetter = true;
                }
                else if (System.Char.IsDigit(c))
                {
                    containsDigit = true;
                }
            }
            return (containsLetter && containsDigit);
        }
        public static bool CheckIfStringIsPalindrome(ref System.Collections.Generic.KeyValuePair<bool, int> io_pair, string i_userInput)
        {
            int startIndex = 0, endIndex = i_userInput.Length-1;
            if(System.Char.IsDigit(i_userInput[startIndex]))
            {
             io_pair = new System.Collections.Generic.KeyValuePair<bool, int>(true, System.Convert.ToInt32(i_userInput));
            }
            return IsPalindrome(i_userInput, startIndex, endIndex);
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
        System.Console.WriteLine("\nSummary:\n================\n");
        System.Console.WriteLine(string.Format("1. The string is{0}a palindrome\n2. The string is{1}a number", i_isPalindrom?" ":" not ", i_isANumberBool? " ": " not "));
        if(i_isANumberBool)
        {
            System.Console.WriteLine(string.Format("3. {0}\n", i_isDevidedBy3 ? "The number devides by 3" : " The number doesn't devides by 3 "));
        }
        else
        {
            System.Console.WriteLine(string.Format("3. The number of upper-case letters is: {0}\n", i_uppercaseCount));
        }
        System.Console.WriteLine("================\n");
        System.Console.WriteLine("Press any key to exit\n");
        System.Console.ReadLine();
    }
}

