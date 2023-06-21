using Microsoft.VisualStudio.TestPlatform.TestHost;
using WordCloudGenerator;

namespace WordCloudGeneratorTesting
{
    public class UnitTest1
    {
        [Fact]
        //[DeploymentItem(@"MyProject.Tests\TestFiles\file.txt")]
        public void Read_In_Text_file_ShouldCheckFile()
        {
            // Arrange
            string filePath = @"data.txt";
            WordGenerator wordGenerator = new WordGenerator();

            // Act
            bool fileExists = wordGenerator.FileExists(filePath);

            // Assert
            Assert.True(fileExists);

        }

        [Fact]
        public void Read_In_Text_file_ShouldReturnFileContents()
        {
            // Arrange
            string expectedContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            string filePath = @"data.txt";
            //WordGenerator wordGenerator = new WordGenerator();

            // Act
            string[] result = ReturnFileContent(filePath);
            string firstLineResult = result.FirstOrDefault();
            //bool resultContains = firstLine.Contains(expectedContent);

            // Assert
            Assert.Contains(expectedContent, firstLineResult);
        }

        string[] ReturnFileContent(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);
            return content;

        }
    }
}