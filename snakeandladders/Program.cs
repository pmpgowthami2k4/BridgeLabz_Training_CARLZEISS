using System;

namespace SnakeAndLadderUserPlay
{
    enum Option
    {
        NoPlay = 0,
        Ladder = 1,
        Snake = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int WINNING_POSITION = 100;

            Console.Write("Enter number of players (1/2/3/4): ");
            int playerCount = int.Parse(Console.ReadLine());

            int[] positions = new int[playerCount];
            int diceCount = 0;

            Random random = new Random();
            int currentPlayer = 0;

            Console.WriteLine("\n🎲 Snake and Ladder Game Started 🎲\n");

            while (true)
            {
                Console.Write($"Player {currentPlayer + 1} turn → Press Y to roll dice | P to pass: ");
                char choice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (choice == 'P')
                {
                    Console.WriteLine($"Player {currentPlayer + 1} passed.\n");
                    currentPlayer = (currentPlayer + 1) % playerCount;
                    continue;
                }

                if (choice != 'Y')
                {
                    Console.WriteLine("Invalid input. Try again.\n");
                    continue;
                }

                int dice = random.Next(1, 7);
                diceCount++;

                Option option = (Option)random.Next(0, 3);

                Console.WriteLine($"Player {currentPlayer + 1} rolled {dice} and got {option}");

                int previousPosition = positions[currentPlayer];

                positions[currentPlayer] = UpdatePosition(
                    positions[currentPlayer],
                    dice,
                    option
                );

                Console.WriteLine($"Player {currentPlayer + 1} position: {positions[currentPlayer]}\n");

                // Win check
                if (positions[currentPlayer] == WINNING_POSITION)
                {
                    Console.WriteLine($"🏆 Player {currentPlayer + 1} WON THE GAME!");
                    Console.WriteLine($"🎯 Total Dice Rolls: {diceCount}");
                    break;
                }

                // If not ladder, move to next player
                if (option != Option.Ladder)
                {
                    currentPlayer = (currentPlayer + 1) % playerCount;
                }
                else
                {
                    Console.WriteLine("🎉 Ladder! Player gets another turn.\n");
                }
            }

            Console.ReadLine();
        }

        static int UpdatePosition(int position, int dice, Option option)
        {
            switch (option)
            {
                case Option.Ladder:
                    position += dice;
                    break;

                case Option.Snake:
                    position -= dice;
                    break;

                case Option.NoPlay:
                    break;
            }

            if (position < 0)
                position = 0;

            if (position > 100)
                position -= dice;

            return position;
        }
    }
}
