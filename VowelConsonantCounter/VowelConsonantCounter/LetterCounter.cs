namespace VowelConsonantCounter
{
    public class LetterCounter
    {
        public HashSet<char> Vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        public HashSet<char> Consonants = new HashSet<char>()
            {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
            };

        public int GetTotalLetterCategory(string? wordToCount, HashSet<char> letterCategory)
        {
            if (wordToCount == null) return 0;
            string? wordLower = wordToCount.ToLower();

            int totalLetterCategory = wordLower.Count(c => letterCategory.Contains(c));
            return totalLetterCategory;
        }

        public int GetWordLength(string? wordToCount)
        {
            if (wordToCount == null) return 0;
            int letterCounter = wordToCount.Length;

            return letterCounter;
        }
    }
}