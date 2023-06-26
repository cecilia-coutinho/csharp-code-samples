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
            char[] validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+[{]}:>|/?".ToCharArray();
            //PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            string password = GeneratePassword(length);

            //Assert
            password.Should().NotBeNullOrEmpty();
            password.Should().NotBeNullOrWhiteSpace();
            password.Length.Should().Be(length);
            password.ToCharArray().All(c => validCharacters.Contains(c)).Should().BeTrue();
        }

        string GeneratePassword(int lenght)
        {
            PasswordGenerator passGenerator = new PasswordGenerator();
            char[] validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+[{]}:>|/?".ToCharArray();

            int minIndex = 0;
            int maxIndex = validCharacters.Length - 1;

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var password = new char[lenght];

                for (int i = 0; i < password.Length; i++)
                {
                    int randomIndex = passGenerator.GetRandomIntWithinRange(randomNumberGenerator, minIndex, maxIndex);
                    char randomCharacter = validCharacters[randomIndex];
                    password[i] = randomCharacter;
                }
                return new string(password);
            }
        }

    }
}