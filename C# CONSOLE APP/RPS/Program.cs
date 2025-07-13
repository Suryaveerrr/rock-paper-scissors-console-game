using System;

class Program
{
    static void Main()
    {
        Console.Title = "Rock Paper Scissors";
        Console.ForegroundColor = ConsoleColor.Cyan;

        ShowIntro();

        ConsoleKey key = Console.ReadKey(true).Key;

        if (key != ConsoleKey.S)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou exited the game.");
            Console.ResetColor();
            return;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Game Started! First to 3 wins. Type 'quit' anytime to exit.\n");

        string[] options = { "rock", "paper", "scissors" };
        int playerScore = 0;
        int cpuScore = 0;
        Random rand = new Random();

        while (true)
        {
            Console.Write("Your move (rock/paper/scissors): ");
            string playerInput = Console.ReadLine().Trim().ToLower();

            if (playerInput == "quit")
            {
                Console.WriteLine("\nYou quit the game.");
                break;
            }

            if (Array.IndexOf(options, playerInput) == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter rock, paper, or scissors.");
                Console.ResetColor();
                continue;
            }

            string cpuChoice = options[rand.Next(options.Length)];
            Console.WriteLine("CPU chose: " + cpuChoice);

            string result = GetResult(playerInput, cpuChoice);

            if (result == "win")
            {
                playerScore++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You win this round!");
            }
            else if (result == "lose")
            {
                cpuScore++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose this round.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It's a draw.");
            }

            Console.ResetColor();
            Console.WriteLine("Score - You: {0} | CPU: {1}\n", playerScore, cpuScore);

            if (playerScore == 3 || cpuScore == 3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(playerScore == 3 ? "You win the match!" : "CPU wins the match.");
                Console.ResetColor();
                break;
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void ShowIntro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("==========================================");
        Console.WriteLine("             ROCK PAPER SCISSORS          ");
        Console.WriteLine("==========================================");
        Console.WriteLine();
        Console.WriteLine("Instructions:");
        Console.WriteLine("- You're playing against the CPU.");
        Console.WriteLine("- Type 'rock', 'paper', or 'scissors'.");
        Console.WriteLine("- First to 3 wins.");
        Console.WriteLine("- Type 'quit' anytime to exit.");
        Console.WriteLine();
        Console.Write("Press 'S' to start or any other key to quit: ");
        Console.ResetColor();
    }

    static string GetResult(string player, string cpu)
    {
        if (player == cpu) return "draw";

        if ((player == "rock" && cpu == "scissors") ||
            (player == "paper" && cpu == "rock") ||
            (player == "scissors" && cpu == "paper"))
        {
            return "win";
        }

        return "lose";
    }
}
