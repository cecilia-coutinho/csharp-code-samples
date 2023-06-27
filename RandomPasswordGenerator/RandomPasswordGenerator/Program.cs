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
            HashGenerator hashGenerator = new HashGenerator();
            bool generateAgain = true;
            string password = passGenerator.GeneratePassword(8);

            Console.WriteLine("\nWelcome to Random Password Generator App!");
            RunData(password, passGenerator, hashGenerator);

            while (generateAgain)
            {
                Console.Write("\nDo you want to generate a new password? (Y/N): ");
                char again = char.ToLower(Console.ReadKey().KeyChar);

                if (again == 'y')
                {
                    string newPassword = passGenerator.GeneratePassword(8);
                    RunData(newPassword, passGenerator, hashGenerator);
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

        static void RunData(string password, PasswordGenerator passGenerator, HashGenerator hashGenerator)
        {
            Console.WriteLine($"\nPassword:");
            Console.WriteLine(password);

            Console.WriteLine($"\nHashed Password:");
            Console.WriteLine(hashGenerator.GetHashedPassword(password));

            Console.WriteLine($"\nVerified Hash:");
            Console.WriteLine(hashGenerator.RunVerifyHashing(password));
        }
    }
}
