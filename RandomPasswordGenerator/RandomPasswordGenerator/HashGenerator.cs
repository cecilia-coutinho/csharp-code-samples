using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

[assembly: InternalsVisibleTo("RandomPasswordGeneratorTest")]

namespace RandomPasswordGenerator
{
    internal class HashGenerator
    {
        private static readonly int _iterations = 50000;
        private static readonly int _keySize = 32; //256bits
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;

        public static readonly char _segmentDelimiter = ':';

        private static string GenerateHash(string input)
        {
            var salt = PasswordGenerator.GetSalt();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = BitConverter.GetBytes(salt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                inputBytes,
                saltBytes,
                _iterations,
                _hashAlgorithm,
                _keySize
                );

            return string.Join(
                _segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(saltBytes),
                _iterations,
                _hashAlgorithm
                );
        }
        public string GetHashedPassword(string password)
        {
            string hashedString = GenerateHash(password);
            return hashedString;
        }

        public bool VerifyHashing(string input, string hashedString)
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

        public bool RunVerifyHashing(string password)
        {
            string hashedString = GetHashedPassword(password);
            bool isPasswordCorrect = VerifyHashing(password, hashedString);

            return isPasswordCorrect;
        }
    }
}
