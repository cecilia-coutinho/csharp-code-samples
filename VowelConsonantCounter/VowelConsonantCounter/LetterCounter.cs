namespace VowelConsonantCounter
{
    public class LetterCounter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int GetWordLength(string wordToCount)
        {
            int letterCounter = wordToCount.Length;

            return letterCounter;
        }
    }
}