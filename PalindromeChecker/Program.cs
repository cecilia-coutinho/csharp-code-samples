namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A palindrome looks the same after reverse.
            Console.Write("Write a word: ");
            string? stringToCheck = Console.ReadLine();
            CheckPalidromeString(stringToCheck);

            Console.Write("Write a sequence of numbers: ");
            int.TryParse(Console.ReadLine(), out int numberToCheck);
            CheckPalidromeInteger(numberToCheck);
        }

        static void CheckPalidromeString(string? stringToCheck)
        {
            if (stringToCheck == null)
            {
                return;
            }

            char[] chars = stringToCheck.ToCharArray();
            Array.Reverse(chars);

            string reverse = new string(chars);
            bool isPalindrome = stringToCheck.Equals(reverse, StringComparison.OrdinalIgnoreCase);

            if (isPalindrome)
            {
                Console.WriteLine($"'{stringToCheck}' is a Palindrome ==> Reverse: {reverse}");
            }
            else
            {
                Console.WriteLine($"'{stringToCheck}' is NOT a Palindrome ==> Reverse: {reverse}");
            }
        }

        static void CheckPalidromeInteger(int numberToCheck)
        {
            int reversedNumber = 0;
            // Store the original number in a temporary variable for comparison
            int temp = numberToCheck;

            // Reverse the original number and store it in 'reversedNumber'

            while (numberToCheck > 0)
            {
                int remainder = numberToCheck % 10; // Extract the last digit of the original number
                reversedNumber = (reversedNumber * 10) + remainder; // Add the last digit to reversedNumber
                numberToCheck = numberToCheck / 10; // Remove the last digit from the original number
            }

            // Compare the original number with its reversed form to determine if it's a palindrome
            if (temp == reversedNumber)
            {
                Console.WriteLine($"'The number '{temp}' is a Palindrome ==> Reverse: {reversedNumber}");
            }
            else
            {
                Console.WriteLine($"'The number '{temp}' is NOT a Palindrome ==> Reverse: {reversedNumber}");
            }
        }
    }
}