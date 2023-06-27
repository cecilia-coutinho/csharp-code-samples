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
            //Act
            int randomInt = PasswordGenerator.GetSalt();

            //Assert
            randomInt.Should().NotBe(0);
        }

        [Fact]
        public void Get_Random_Int_Should_NotReturn_MaxValue()
        {
            //Act
            int randomInt = PasswordGenerator.GetSalt();

            //Assert
            randomInt.Should().NotBe(int.MaxValue);
        }

        [Fact]
        public void Get_Random_Int_Should_NotReturn_MinValue()
        {
            //Act
            int randomInt = PasswordGenerator.GetSalt();

            //Assert
            randomInt.Should().NotBe(int.MinValue);
        }

        [Fact]
        public void GetRandomIntWithinRange_Should_Return_NonNegative_Integer()
        {
            //Arrange
            int maxInput = 10;

            //Act
            int randomIntWithinRange = PasswordGenerator.GetRandomIntWithinRange(maxInput);

            //Assert
            randomIntWithinRange.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void GetRandomIntWithinRange_Should_Return_Value_Less_Than_MaxInput()
        {
            //Arrange
            int maxInput = 10;

            //Act
            int randomIntWithinRange = PasswordGenerator.GetRandomIntWithinRange(maxInput);

            //Assert
            randomIntWithinRange.Should().BeLessThan(maxInput);
        }

        [Fact]
        public void GeneratePassword_Should_Return_NonEmpty_String()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            string password = passGenerator.GeneratePassword(length);

            //Assert
            password.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GeneratePassword_Should_Return_NonWhiteSpaces_In_Password()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            string password = passGenerator.GeneratePassword(length);

            //Assert
            password.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void GeneratePassword_Should_Return_Valid_Password_Length()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();

            //Act
            string password = passGenerator.GeneratePassword(length);

            //Assert
            password.Length.Should().Be(length);
        }

        [Fact]
        public void GeneratePassword_Should_Return_Valid_Characters()
        {
            //Arrange
            int length = 12;
            PasswordGenerator passGenerator = new PasswordGenerator();
            char[] validCharacters = passGenerator.ValidCharacters;

            //Act
            string password = passGenerator.GeneratePassword(length);

            //Assert
            password.ToCharArray().All(c => validCharacters.Contains(c)).Should().BeTrue();
        }
    }
}