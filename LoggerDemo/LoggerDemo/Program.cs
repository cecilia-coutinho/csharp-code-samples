namespace LoggerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            Logger logger = new Logger();
            Console.WriteLine(logger.WriteLog("lorem ipsum"));
        }
    }
}