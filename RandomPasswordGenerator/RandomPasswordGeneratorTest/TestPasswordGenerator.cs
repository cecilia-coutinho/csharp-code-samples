using FluentAssertions;
using RandomPasswordGenerator;
using System.Security.Cryptography;

namespace RandomPasswordGeneratorTest
{
    public class TestPasswordGenerator
    {
        [Fact]
        public void Get_Random_Int_Should_Return_Valid_Randon_Number()
        {
            //Arrange
            RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create();

            //Act
            int randomInt = PasswordGenerator.GetSalt(randomGenerator);

            //Assert
            randomInt.Should().NotBe(0);
            randomInt.Should().NotBe(int.MaxValue);
            randomInt.Should().NotBe(int.MinValue);
        }

        [Fact]
        public void GetRandomIntWithinRange_Should_Return_RandomInt_Within_Range()
        {
            //Arrange
            RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create();
            int maxInput = 10;

            //Act
            int randomIntWithinRange = PasswordGenerator.GetRandomIntWithinRange(randomGenerator, maxInput);

            //Assert
            randomIntWithinRange.Should().BeGreaterOrEqualTo(0);
            randomIntWithinRange.Should().BeLessThan(maxInput);
        }

        [Fact]
        public void GeneratePassword_Should_Return_Valid_Password()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();
            char[] validCharacters = passGenerator.ValidCharacters;

            //Act
            string password = passGenerator.GeneratePassword(length);

            //Assert
            password.Should().NotBeNullOrEmpty();
            password.Should().NotBeNullOrWhiteSpace();
            password.Length.Should().Be(length);
            password.ToCharArray().All(c => validCharacters.Contains(c)).Should().BeTrue();
        }
    }
}