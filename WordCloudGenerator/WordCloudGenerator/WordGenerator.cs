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
            "is", "an", "that", "uses", "and", "to", "from", "it", "and", "in", "are", "as", "at", "be", "but", "by", "can", "did", "do", "does", "each", "for", "how", "i", "if", "is", "it", "its", "just", "may", "me", "might", "my", "nor", "not", "of", "when", "where", "which", "while", "who", "why", "with", "without", "yes", "you"
        };


        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string[] ReturnFileContent(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);
            return content;
        }
    }
}
