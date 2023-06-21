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
            Dictionary<string, int> result = wordGenerator.GenerateWordCloud(FilePath);

            //Assert
            result.Should().HaveCount(8);
        }


        [Fact]
        public void Generate_Word_Cloud_ShouldRemoveStopWords()
        {
            // Arrange
            WordGenerator wordGenerator = new WordGenerator();
            var stopwords = wordGenerator.StopWords;
            Dictionary<string, int> dictionary = wordGenerator.GenerateWordCloud(FilePath);

            //Act
            IEnumerable<string> filteredWords = wordGenerator.FilteredWords(dictionary, stopwords);

            //Assert
            filteredWords.Should().NotContain(stopwords);
        }
    }
}