using static System.Console;

namespace PrimeNumberChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prime number is a number that is greater than 1 and divided by 1 or itself. In other words, prime numbers can't be divided by other numbers than itself or 1. For example 2, 3, 5, 7, 11, 13, 17, 19, 23.... are the prime numbers.
            int isPrime = 0;

            //Take an input from the user
            Write("Enter the Number to check Prime: ");
            int.TryParse(ReadLine(), out int numberToCheck);

            //check whether the number is prime or not
            int maximumDivisor = numberToCheck / 2; //half of the number being checked

            //i = divisor (smallest possible divisor (other than 1))
            for (int i = 2; i < maximumDivisor; i++)
            {
                if (numberToCheck % i == 0)
                {
                    //Print result if it's not prime
                    Console.WriteLine($"Number {numberToCheck} is not prime");
                    isPrime = 1;
                    break;
                }
            }

            if (isPrime == 0)
            {
                //Print result if is prime
                Console.WriteLine($"Number {numberToCheck} is prime");
            }
        }
    }
}