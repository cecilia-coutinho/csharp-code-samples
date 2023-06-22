namespace CsvReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read in the data from the CSV file
            string[] lines = File.ReadAllLines("data.csv");
            CreateTableForEachLoop(lines);
            CreateTableForLoop(lines);
        }

        static void CreateTableForEachLoop(string[] lines)
        {
            // Reader for the table
            Console.WriteLine("\n|--------------|-------|------------|-------------|");
            Console.WriteLine("| {0,-12} | {1,-5} | {2,-10} | {3,-11} |", "Name", "Age", "Gender", "Occupation");
            Console.WriteLine("|--------------|-------|------------|-------------|");
            foreach (string line in lines.Skip(1))
            {
                string[] data = line.Split(',');

                //output values in the table
                Console.WriteLine("| {0,-12} | {1,-5} | {2,-10} | {3,-11} |", data[0], data[1], data[2], data[3]);

            }
            Console.WriteLine("|--------------|-------|------------|-------------|\n");
        }
        static void CreateTableForLoop(string[] lines)
        {
            // Split the lines into fields and store in a two-dimensional array
            string[,] data = new string[lines.Length, 4];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                for (int j = 0; j < 4; j++)
                {
                    data[i, j] = fields[j].Trim();
                }
            }

            // Output the data in a formatted table
            Console.WriteLine("\n|--------------|------|--------|------------|");
            Console.WriteLine("| {0,-12} | {1,-4} | {2,-6} | {3,-10} |", "Name", "Age", "Gender", "Occupation");
            Console.WriteLine("|--------------|------|--------|------------|");
            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine("| {0,-12} | {1,-4} | {2,-6} | {3,-10} |", data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
            }
            Console.WriteLine("|--------------|------|--------|------------|\n");
        }
    }
}