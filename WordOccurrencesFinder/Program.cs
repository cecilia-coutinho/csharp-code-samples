using System.Text.RegularExpressions;
using static System.Console;

// See https://aka.ms/new-console-template for more information
string text = File.ReadAllText("input.txt").ToLower();

int theWord = Regex.Matches(text, @"\bthe\b").Count;
WriteLine($"The word 'The' has {theWord} ocurrences in the text");

Write("write a word for the search: ");
string? wordToSearch = Console.ReadLine();
int wordCounter = Regex.Matches(text, $@"\b{wordToSearch}\b").Count;
WriteLine($"\nThe word {wordToSearch} has {wordCounter} ocurrences in the text");