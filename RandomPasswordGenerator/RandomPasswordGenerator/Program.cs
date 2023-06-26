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

            Console.WriteLine("\nWelcome to Random Password Generator App!");

            Console.WriteLine($"\nPassword:");
            Console.WriteLine(passGenerator.GeneratePassword(8));
        }
    }
}
