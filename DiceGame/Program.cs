namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayDiceGame();
            bool playAgain = true;
            while (playAgain)
            {
                Console.Write("Do you want to roll the dice again? (Y/N): ");
                char again = char.ToLower(Console.ReadKey().KeyChar);
                Console.ReadLine();

                if (again == 'y')
                {
                    PlayDiceGame();
                }
                else if (again == 'n')
                {
                    playAgain = false;
                }
                else
                {
                    Console.WriteLine("Not a valid answer. Please enter y or n\n");
                }
            }
            Console.WriteLine("\nThanks for playing!\n");
        }

        static void PlayDiceGame()
        {
            Console.Write("\nEnter the number of dice you want to roll: ");
            int.TryParse(Console.ReadLine(), out int numDice);

            Console.Write("Enter the number of sides on each die: ");
            int.TryParse(Console.ReadLine(), out int numSides);

            //Validate inputs to ensure they are positive integers
            if (numDice <= 0 || numSides <= 0)
            {
                Console.Write("You must enter a positive number.\n");
                return;
            }

            // Roll the dice and display the results to the user
            Random rnd = new Random();

            for (int i = 0; i < numDice; i++)
            {
                int rollResult = rnd.Next(1, numSides + 1);
                Console.WriteLine("Dice result: " + rollResult);
            }
        }
    }
}