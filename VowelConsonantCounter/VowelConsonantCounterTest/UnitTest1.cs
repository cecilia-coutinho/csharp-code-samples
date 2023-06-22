using FluentAssertions;
using System.Text.RegularExpressions;
using VowelConsonantCounter;

namespace VowelConsonantCounterTest
{
    public class UnitTest1
    {
        [Fact]
        public void Vowel_Consonant_Counter_ShouldReturnLength()
        {
            // Arrange
            string word = "Dice";
            LetterCounter counter = new LetterCounter();

            // Act
            int letterCounter = counter.GetWordLength(word);

            // Assert
            letterCounter.Should().Be(4);
        }

        //int GetWordLength(string wordToCount)
        //{
        //    int letterCounter = wordToCount.Length;

        //    return letterCounter;
        //}
    }
}