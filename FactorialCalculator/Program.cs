using static System.Console;

namespace FactorialCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Factorial Program in C#: Factorial of n is the product of all positive descending integers. Factorial of n is denoted by n!.
            // 4! = 4*3*2*1 = 24    
            // 6! = 6*5*4*3*2*1 = 720 
            int factorial = 1;

            //Get user input
            Write("Enter any Number: ");
            int.TryParse(Console.ReadLine(), out int numberToCalculate);

            //Calculate factorial
            for (int i = 1; i <= numberToCalculate; i++)
            {
                factorial = factorial * i;
            }

            //Print Result
            WriteLine($"The factorial of {numberToCalculate} is {factorial}");
        }
    }
}