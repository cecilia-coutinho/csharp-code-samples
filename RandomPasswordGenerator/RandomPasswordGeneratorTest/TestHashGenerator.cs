using FluentAssertions;
using RandomPasswordGenerator;
using System.Security.Cryptography;
using System.Text;

namespace RandomPasswordGeneratorTest
{
    public class TestHashGenerator
    {
        [Fact]
        public void GetHashedPassword_Should_Return_Hashed_String_With_Salt()
        {
            //Arrange
            string input = "password";
            HashGenerator hasher = new HashGenerator();

            //Act
            string hashedString = hasher.GetHashedPassword(input);

            //Assert
            hashedString.Should().NotBeNullOrEmpty();
            hashedString.Should().ContainAll(":");
        }

        [Fact]
        public void VerifyHashing_Should_Return_True_For_Valid_Password()
        {
            // Arrange
            string password = "password";
            string hashedString = "43BBF0677DEFC603816610CA41581DEB14B17C09CCCA0093900BA95B0AF1D9B8:F5451A79:50000:SHA256";
            HashGenerator hasher = new HashGenerator();

            //Act
            bool result = hasher.VerifyHashing(password, hashedString);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void VerifyHashing_Should_Return_False_For_Invalid_Password()
        {
            // Arrange
            string password = "invalidpassword";
            string hashedString = "43BBF0677DEFC603816610CA41581DEB14B17C09CCCA0093900BA95B0AF1D9B8:F5451A79:50000:SHA256";
            HashGenerator hasher = new HashGenerator();

            //Act
            bool result = hasher.VerifyHashing(password, hashedString);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void VerifyHashing_Should_Return_False_For_Empty_Password()
        {
            // Arrange
            string password = string.Empty;
            string hashedString = "43BBF0677DEFC603816610CA41581DEB14B17C09CCCA0093900BA95B0AF1D9B8:F5451A79:50000:SHA256";
            HashGenerator hasher = new HashGenerator();

            //Act
            bool result = hasher.VerifyHashing(password, hashedString);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void RunVerifyHashing_Should_Return_True_For_Valid_Password()
        {
            // Arrange
            string password = "password";
            HashGenerator hasher = new HashGenerator();

            //Act
            bool result = hasher.RunVerifyHashing(password);

            //Assert
            result.Should().BeTrue();
        }

    }
}
