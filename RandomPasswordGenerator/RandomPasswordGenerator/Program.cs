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
            string password = passGenerator.GeneratePassword(8);

            Console.WriteLine("\nWelcome to Random Password Generator App!");
            RunData(password);

            while (generateAgain)
            {
                Console.Write("\nDo you want to generate a new password? (Y/N): ");
                char again = char.ToLower(Console.ReadKey().KeyChar);

                if (again == 'y')
                {
                    string newPassword = passGenerator.GeneratePassword(8);
                    RunData(newPassword);
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

        static void RunData(string password)
        {
            HashGenerator hashGenerator = new HashGenerator();

            Console.WriteLine($"\nPassword:");
            Console.WriteLine(password);

            Console.WriteLine($"\nHashed Password:");
            Console.WriteLine(hashGenerator.GetHashedPassword(password));

            Console.WriteLine($"\nVerified Hash:");
            Console.WriteLine(hashGenerator.RunVerifyHashing(password));
        }
    }
}
