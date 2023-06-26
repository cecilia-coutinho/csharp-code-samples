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
            int minLength = 8;
            int maxLength = 12;
            char[] validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+[{]}:>|/?".ToCharArray();
            //PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            string password = GeneratePassword(minLength, maxLength);

            //Assert
            password.Should().NotBeNullOrEmpty();
            password.Should().NotBeNullOrWhiteSpace();
            password.Length.Should().BeGreaterThanOrEqualTo(minLength);
            password.Length.Should().BeLessThanOrEqualTo(maxLength);
            password.ToCharArray().All(c => validCharacters.Contains(c)).Should().BeTrue();
        }

        string GeneratePassword(int minLength, int maxLength)
        {
            PasswordGenerator passGenerator = new PasswordGenerator();
            char[] validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+[{]}:>|/?".ToCharArray();

            int minLengthIndex = 0;
            int maxLengthIndex = validCharacters.Length - 1;

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var passwordLength = passGenerator.GetRandomIntWithinRange(randomNumberGenerator, minLength, maxLength);
                var password = new char[passwordLength];

                for (int i = 0; i < password.Length; i++)
                {
                    int randomIndex = passGenerator.GetRandomIntWithinRange(randomNumberGenerator, minLengthIndex, maxLengthIndex);
                    char randomCharacter = validCharacters[randomIndex];
                    password[i] = randomCharacter;
                }
                return new string(password);
            }

        }

    }
}