namespace LoggerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            Console.WriteLine(logger.WriteLog("lorem ipsum."));

            Console.WriteLine("\n ----------------------\n");
            Console.WriteLine(logger.ReadLogs());
        }
    }
}