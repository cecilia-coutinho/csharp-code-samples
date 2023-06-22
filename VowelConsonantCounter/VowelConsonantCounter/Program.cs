using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelConsonantCounter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LetterCounter counter = new LetterCounter();

            Console.WriteLine("\nWelcome to Letter Counter App!");

            while (true)
            {
                Console.Write("\nWrite a text or word: ");
                string? wordToCount = Console.ReadLine();

                int totalConsonants = counter.GetTotalLetterCategory(wordToCount, counter.Consonants);
                int totalVowels = counter.GetTotalLetterCategory(wordToCount, counter.Vowels);
                int totalCharacters = counter.GetWordLength(wordToCount);
                int totalCharactersWithoutSpace = counter.GetWordLength(wordToCount?.Replace(" ", ""));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nRESULTS:");
                Console.ResetColor();
                Console.WriteLine($"Word/Text: {wordToCount};\n" +
                    $"number of characters (with space): {totalCharacters};\n" +
                    $"number of characters (without space): {totalCharactersWithoutSpace};\n" +
                    $"Number of Vowels: {totalVowels};\n" +
                    $"Number of Consonants: {totalConsonants}");
            }
        }
    }
}
