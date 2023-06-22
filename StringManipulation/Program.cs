using static System.Console;


namespace StringManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a text: ");
            string? textToReverse = Console.ReadLine();
            Console.WriteLine(ReverseString(textToReverse));
        }

        static string ReverseString(string? textToReverse)
        {
            string? reversedString = new string(textToReverse?.Reverse().ToArray());
            return reversedString;
        }
    }
}