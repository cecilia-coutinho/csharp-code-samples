using FluentAssertions;
using System.Text.RegularExpressions;
using VowelConsonantCounter;

namespace VowelConsonantCounterTest
{
    public class UnitTest1
    {
        [Fact]
        public void Vowel_Consonant_Counter_ShouldReturnWordLength()
        {
            // Arrange
            string word = "Dice";
            LetterCounter counter = new LetterCounter();

            // Act
            int letterCounter = counter.GetWordLength(word);

            // Assert
            letterCounter.Should().Be(4);
        }
        [Fact]
        public void Vowel_Consonant_Counter_ShouldReturnTotalVowels()
        {
            // Arrange
            string word = "Dice";
            string word2 = "dIce";
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            LetterCounter counter = new LetterCounter();

            // Act
            int letterCounter = counter.GetTotalLetterCategory(word, vowels);
            int letterCounter2 = counter.GetTotalLetterCategory(word2, vowels);

            // Assert
            letterCounter.Should().Be(2);
            letterCounter2.Should().Be(2);
        }

        [Fact]
        public void Vowel_Consonant_Counter_ShouldReturnTotalConsonants()
        {
            // Arrange
            string word = "BimBIM";
            var consonants = new HashSet<char>()
            {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
            };
            LetterCounter counter = new LetterCounter();

            // Act
            int letterCounter = counter.GetTotalLetterCategory(word, consonants);

            // Assert
            letterCounter.Should().Be(4);
        }
    }
}