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

            //Act
            bool result = VerifyHashing(password, hashedString);

            //Assert
            result.Should().BeTrue();
        }

        bool VerifyHashing(string input, string hashedString)
        {
            string[] segments = hashedString.Split(HashGenerator._segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithmName = new HashAlgorithmName(segments[3]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                input,
                salt,
                iterations,
                algorithmName,
                hash.Length
                );

            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
    }
}
