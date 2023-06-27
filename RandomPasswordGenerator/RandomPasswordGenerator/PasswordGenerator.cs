using System.Security.Cryptography;

namespace RandomPasswordGenerator
{
    public class PasswordGenerator
    {
        public readonly char[] validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*_-+>|?".ToCharArray();

        public string GeneratePassword(int lenght)
        {
            // max index for validCharacters array
            int maxIndex = validCharacters.Length;

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var password = new char[lenght]; //store password in a char array

                for (int i = 0; i < password.Length; i++)
                {
                    // Generate a random index within specified range
                    int randomIndex = GetRandomIntWithinRange(randomNumberGenerator, maxIndex);

                    // Retrieve random character from the validCharacters array
                    char randomCharacter = validCharacters[randomIndex];

                    // Assign the random char to the corresponding position in the password array
                    password[i] = randomCharacter;
                }
                // Convert the char array to a string and return the password
                return new string(password);
            }
        }

        public int GetSalt(RandomNumberGenerator randomNumberGenerator)
        {
            byte[] buffer = new byte[8]; // byte array to store the random bytes
            randomNumberGenerator.GetBytes(buffer); // Generate salt
            int randomInt = (int)BitConverter.ToInt64(buffer); // Convert the random bytes
            return randomInt;
        }

        public int GetRandomIntWithinRange(RandomNumberGenerator randomGenerator, int maxInput)
        {
            return Math.Abs(GetSalt(randomGenerator) % maxInput);
        }
    }
}