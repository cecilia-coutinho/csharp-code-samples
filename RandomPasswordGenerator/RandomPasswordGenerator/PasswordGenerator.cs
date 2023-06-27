using System.Runtime.CompilerServices;
using System.Security.Cryptography;

[assembly: InternalsVisibleTo("RandomPasswordGeneratorTest")]

namespace RandomPasswordGenerator
{
    internal class PasswordGenerator
    {
        public readonly char[] ValidCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*_-+>|?".ToCharArray();
        private static readonly int _saltSize = 16; //128bits

        public string GeneratePassword(int lenght)
        {
            // max index for ValidCharacters array
            int maxIndex = ValidCharacters.Length;

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var password = new char[lenght]; //store password in a char array

                for (int i = 0; i < password.Length; i++)
                {
                    // Generate a random index within specified range
                    int randomIndex = GetRandomIntWithinRange(randomNumberGenerator, maxIndex);

                    // Retrieve random character from the ValidCharacters array
                    char randomCharacter = ValidCharacters[randomIndex];

                    // Assign the random char to the corresponding position in the password array
                    password[i] = randomCharacter;
                }
                // Convert the char array to a string and return the password
                return new string(password);
            }
        }

        public static int GetSalt(RandomNumberGenerator randomNumberGenerator)
        {
            byte[] buffer = new byte[_saltSize]; // byte array to store the random bytes
            randomNumberGenerator.GetBytes(buffer); // Generate salt
            int randomInt = (int)BitConverter.ToInt64(buffer); // Convert the random bytes
            return randomInt;
        }

        public static int GetRandomIntWithinRange(RandomNumberGenerator randomGenerator, int maxInput)
        {
            return Math.Abs(GetSalt(randomGenerator) % maxInput);
        }
    }
}