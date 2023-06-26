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
            PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            int randomInt = passGenerator.GetRandomInt(randomGenerator);

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
            PasswordGenerator passGenerator = new PasswordGenerator();
            int minInput = 10;
            int maxInput = 20;

            //Act
            int randomIntWithinRange = passGenerator.GetRandomIntWithinRange(randomGenerator, minInput, maxInput);

            //Assert
            randomIntWithinRange.Should().BeInRange(minInput, maxInput);
        }

        [Fact]
        public void GeneratePassword_Should_Return_Valid_Password()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();
            char[] validCharacters = passGenerator.validCharacters;

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