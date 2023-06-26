using System.Security.Cryptography;

namespace RandomPasswordGenerator
{
    public class PasswordGenerator
    {
        static void Main(string[] args)
        {
        }

        public int GetRandomInt(RandomNumberGenerator randomNumberGenerator)
        {
            byte[] buffer = new byte[8]; // byte array to store the random bytes
            randomNumberGenerator.GetBytes(buffer); // Generate random bytes

            int randomInt = BitConverter.ToInt32(buffer); // Convert the random bytes
            return randomInt;
        }

        public int GetRandomIntWithinRange(RandomNumberGenerator randomGenerator, int minInput, int maxInput)
        {
            return Math.Clamp(GetRandomInt(randomGenerator), minInput, maxInput);
        }
    }
}