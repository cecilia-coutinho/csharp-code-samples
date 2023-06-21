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
    }
}