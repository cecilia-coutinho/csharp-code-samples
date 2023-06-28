using System.Xml.Linq;

namespace SecretSanta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Secret Santa!");
            Console.Write("Enter the names of the participants separated by commas:");
            string? names = Console.ReadLine();
            //string? names = "A, B, C, D, E, F, G";
            List<string> namesList;

            if (string.IsNullOrWhiteSpace(names) || !names.Contains(","))
            {
                Console.WriteLine("Unable to assign a unique secret friend. Please try again.");
                return;
            }
            else
            {
                namesList = new List<string>(names.Split(','));
            }

            Random rand = new Random();
            var shuffledNames = namesList.OrderBy(a => rand.Next()).ToList();

            //key= person, value = secret friend
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            for (int i = 0; i < namesList.Count; i++)
            {
                string name = namesList[i];
                string? secretFriend = shuffledNames.FirstOrDefault();

                if (secretFriend != null && name != secretFriend)
                {
                    keyValuePairs.Add(name, secretFriend);
                    shuffledNames.RemoveAt(shuffledNames.IndexOf(secretFriend));
                }
                else if (shuffledNames.Count > 1)
                {
                    secretFriend = shuffledNames
                    .SkipWhile(a => keyValuePairs.ContainsValue(a))
                    .Skip(1)
                    .FirstOrDefault()!;
                    keyValuePairs.Add(name, secretFriend);
                    shuffledNames.RemoveAt(shuffledNames.IndexOf(secretFriend));
                }
                else
                {
                    Console.WriteLine("Unable to assign a unique secret friend. Please try again.");
                    return;
                }
            }

            Console.WriteLine("Secret Santa:");
            foreach (KeyValuePair<string, string> pair in keyValuePairs)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}