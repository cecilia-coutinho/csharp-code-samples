using System.Diagnostics.Metrics;
using System.Globalization;

namespace BasicCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\nWelcome to Console Basic Calculator!\n" +
                "\nA calculator that can perform basic arithmetic operations " +
                "\n(addition, subtraction, multiplication, division) on two numbers.");

            while (true)
            {
                //Prompt the user to enter the operation and two numbers
                var operand1 = GetNUmberFromUser();

                Console.Write("Type operation(+, -, *, /): ");
                char.TryParse(Console.ReadLine(), out char operation);

                var operand2 = GetNUmberFromUser();

                //Display the result to the user
                Calculator calculator = new Calculator(operand1, operand2, operation);
            }
        }

        static double GetNUmberFromUser()
        {
            //loop to prompt the user for input until a valid number is entered
            while (true)
            {
                Console.Write("\nType a number: ");
                string? input = Console.ReadLine();

                /* Specify culture that uses a dot as the decimal separator
                 * to not be affected by the computer's regional settings 
                 */
                CultureInfo culture = CultureInfo.InvariantCulture;

                //replace ',' to '.'
                if (input?.Contains(',') == true)
                {
                    input = input?.Replace(',', '.');
                }

                if (double.TryParse(input, NumberStyles.Float, culture, out var operand))
                {
                    return operand;
                }
                else
                {
                    Console.WriteLine("Invalid number format. Please try again.");
                }
            }
        }
    }
}