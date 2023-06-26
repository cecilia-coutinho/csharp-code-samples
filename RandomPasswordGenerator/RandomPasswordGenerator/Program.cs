using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordGenerator passGenerator = new PasswordGenerator();
            bool generateAgain = true;

            Console.WriteLine("\nWelcome to Random Password Generator App!");
            Console.WriteLine($"\nGenerated Password:");
            Console.WriteLine(passGenerator.GeneratePassword(8));

            while (generateAgain)
            {
                Console.Write("Do you want to generate a new password? (Y/N): ");
                char again = char.ToLower(Console.ReadKey().KeyChar);

                if (again == 'y')
                {
                    Console.WriteLine($"\nNew Password:");
                    Console.WriteLine(passGenerator.GeneratePassword(8));
                }
                else if (again == 'n')
                {
                    generateAgain = false;
                }
                else
                {
                    Console.WriteLine("Not a valid answer. Please enter y or n\n");
                }
            }
            Console.WriteLine("\nThanks for your visit!\n");
        }
    }
}
