using FluentAssertions;
using RandomPasswordGenerator;
using System.Security.Cryptography;
using System.Text;

namespace RandomPasswordGeneratorTest
{
    public class TestHashGenerator
    {
        [Fact]
        public void Returnreturn()
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
    }
}
