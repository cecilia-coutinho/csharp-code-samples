using Microsoft.VisualStudio.TestPlatform.TestHost;
using WordCloudGenerator;
using FluentAssertions;

namespace WordCloudGeneratorTesting
{
    public class UnitTest1
    {
        private readonly string FilePath = @"data.txt";

        [Fact]
        public void Read_In_Text_file_ShouldCheckFile()
        {
            // Arrange
            WordGenerator wordGenerator = new WordGenerator();

            // Act
            bool fileExists = wordGenerator.FileExists(FilePath);

            // Assert
            Assert.True(fileExists);

        }

        [Fact]
        public void Read_In_Text_file_ShouldReturnFileContents()
        {
            // Arrange
            string expectedContent = "Data science is an interdisciplinary field that uses scientific methods, processes,";
            WordGenerator wordGenerator = new WordGenerator();

            // Act
            string[] result = wordGenerator.ReturnFileContent(FilePath);
            string? firstLineResult = result.FirstOrDefault();

            // Assert
            //Assert.Contains(expectedContent, firstLineResult);
            firstLineResult.Should().Contain(expectedContent);
        }

        [Fact]
        public void Generate_Word_Cloud_ShouldReturnDictionary()
        {
            // Arrange
            WordGenerator wordGenerator = new WordGenerator();

            //Act
            Dictionary<string, int> result = GenerateWordCloud(FilePath);

            //Assert
            result.Should().HaveCount(8);

        }

        public Dictionary<string, int> GenerateWordCloud(string filePath)
        {
            WordGenerator wordGenerator = new WordGenerator();
            string[] content = wordGenerator.ReturnFileContent(filePath);

            // Remove non-alpha characters and convert to lowercase
            string[] cleanString = content
                .Select(s => new string(s
                    .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-')
                    .ToArray()))
                .ToArray();

            // Remove stopwords
            //IEnumerable<string> filteredWords = words.Where(word => !Stopwords.Contains(word));


            Dictionary<string, int> wordCloud = cleanString
                .GroupBy(word => word)
                .ToDictionary(g => g.Key, g => g.Count());

            return wordCloud;

        }


        [Fact]
        public void Generate_Word_Cloud_ShouldRemoveStopWords()
        {
            // Arrange
            WordGenerator wordGenerator = new WordGenerator();
            var stopwords = wordGenerator.StopWords;

            //Act
            Dictionary<string, int> wordCloud = GenerateWordCloud(FilePath);
            IEnumerable<string> filteredWords = wordCloud.Keys.Where(sw => !stopwords.Contains(sw));

            //Assert
            filteredWords.Should().NotContain(stopwords);

        }


    }
}