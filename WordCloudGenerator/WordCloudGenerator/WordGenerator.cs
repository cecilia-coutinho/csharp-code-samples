using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCloudGenerator
{
    public class WordGenerator
    {
        public readonly HashSet<string> StopWords = new HashSet<string>
        {
            "is", "an", "that", "uses", "and", "to", "from", "it", "and", "in", "are", "as", "at", "be", "but", "by", "can", "did", "do", "does", "each", "for", "how", "i", "if", "is", "it", "its", "just", "may", "me", "might", "my", "nor", "not", "of", "when", "where", "which", "while", "who", "why", "with", "without", "yes", "you", "", "a", "such"
        };

        private readonly string FilePath = @"data.txt";

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string[] ReturnFileContent(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);
            return content;
        }

        public Dictionary<string, int> GenerateWordCloud(string filePath)
        {
            string[] content = ReturnFileContent(filePath);

            // Remove non-alpha characters and convert to lowercase
            string[] cleanString = content
                .SelectMany(s => s.Split(' '))
                .Select(s => new string(s
                    .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-')
                    .ToArray()))
                .ToArray();

            Dictionary<string, int> wordCloud = cleanString
                .GroupBy(word => word.ToLower())
                .ToDictionary(g => g.Key, g => g.Count());

            return wordCloud;
        }

        public IEnumerable<string> FilteredWords(Dictionary<string, int> dictionary, HashSet<string> stopWords)
        {
            IEnumerable<string> filteredWords = dictionary.Keys.Where(sw => !stopWords.Contains(sw));
            return filteredWords;
        }

        public Dictionary<string, int> FilteredDictionary(Dictionary<string, int> dictionary, IEnumerable<string> filteredWords)
        {
            // Apply filtered words and return a new dictionary
            var filteredDictionary = dictionary
                .Where(entry => filteredWords
                    .Contains(entry.Key))
                .ToDictionary(entry => entry.Key, entry => entry.Value);
            return filteredDictionary;
        }
    }
}
