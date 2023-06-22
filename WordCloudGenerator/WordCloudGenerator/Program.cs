namespace WordCloudGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintWordCloud();
        }

        static void PrintWordCloud()
        {
            WordGenerator wordGenerator = new WordGenerator();

            // Generate word cloud
            Dictionary<string, int> wordCloud = wordGenerator.GenerateWordCloud(@"data.txt");

            // Filter the word cloud using the stop words
            IEnumerable<string> filteredWords = wordGenerator.FilteredWords(wordCloud, wordGenerator.StopWords);

            //new dictionary filtered
            var filteredDictionary = wordGenerator.FilteredDictionary(wordCloud, filteredWords);

            foreach (var word in filteredDictionary)
            {
                Console.WriteLine($"Word: {word.Key}, Frequency: {word.Value}");
            }
        }

    }
}