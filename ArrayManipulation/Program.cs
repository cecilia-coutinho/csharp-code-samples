namespace ArrayManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //merge arrays and sort

            int[] firstArrayToMerge = new int[] { 3, 5, 32, 9, 38, 14, 18, 44, 25, 46 };
            int[] secondArrayToMerge = new int[] { 30, 6, 34, 36, 12, 40, 42, 20, 28, 48 };

            int[] merged = firstArrayToMerge.Union(secondArrayToMerge).OrderBy(i => i).ToArray(); //merge with .Union and sort with .OrderBy

            Console.Write(String.Join(",", merged));
        }
    }
}