using FluentAssertions;
using System.Security.Cryptography;

namespace RandomPasswordGeneratorTest
{
    public class TestPasswordGenerator
    {
        [Fact]
        public void Get_Random_In_Should_Return_Valid_Randon_Number()
        {
            //Arrange
            RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create();

            //Act
            int randomInt = GetRandomInt(randomGenerator);

            //Assert
            randomInt.Should().NotBe(0);
            randomInt.Should().NotBe(int.MaxValue);
            randomInt.Should().NotBe(int.MinValue);
        }

        int GetRandomInt(RandomNumberGenerator randomNumberGenerator)
        {
            byte[] buffer = new byte[8]; // byte array to store the random bytes
            randomNumberGenerator.GetBytes(buffer); // Generate random bytes

            int randomInt = BitConverter.ToInt32(buffer); // Convert the random bytes
            return randomInt;
        }
    }
}