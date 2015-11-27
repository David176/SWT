using System;
using System.Collections.Generic;
using System.Threading;

namespace Uno.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(new CardRules(9,0,4));
            UnoGame unoGame = new UnoGame(deck);

            StartOfProgram:
            Console.Clear();
            Console.WriteLine("           ____ ___               ________                        ________ _______  _______  _______             ");
            Console.WriteLine("          |    |   \\____   ____  /  _____/_____    _____   ____   \\_____  \\   _  \\ \\   _  \\ \\   _  \\            ");
            Console.WriteLine("  ______  |    |   /    \\ /  _ \\/   \\  ___\\__  \\  /     \\_/ __ \\    _(__  </  /_\\  \\/  /_\\  \\/  /_\\  \\    ______ ");
            Console.WriteLine(" /_____/  |    |  /   |  (  <_> )    \\_\\  \\/ __ \\|  Y Y  \\  ___/   /       \\  \\_/   \\  \\_/   \\  \\_/   \\  /_____/ ");
            Console.WriteLine("          |______/|___|  /\\____/ \\______  (____  /__|_|  /\\___  > /______  /\\_____  /\\_____  /\\_____  /          ");
            Console.WriteLine("                       \\/               \\/     \\/      \\/     \\/         \\/       \\/       \\/       \\/           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Input number of players between 2-6");
            int players;
            if (int.TryParse(Console.ReadLine(), out players))
            {
                if (players >= 2 && players <= 6)
                    Console.WriteLine("You selected to start a game with "+players+" players");
                else
                {
                    Console.WriteLine("You did not select a number between 2 and 6. Press a key to try again");
                    Console.ReadKey();
                    goto StartOfProgram;
                }
            }
            else
            {
                Console.WriteLine("Incorrect input. Press a key to try again");
                Console.ReadKey();
                goto StartOfProgram;
            }
            for (int i = 0; i < players; i++)
            {
                Console.WriteLine("Please input name of player "+(i+1));
                unoGame.AddPlayer(new Player(unoGame, Console.ReadLine()));
            }
            StartOfGame:
            unoGame.StartGame();
            int selection;
            Console.WriteLine("\nPress 1 to play again with the same players. Press 2 to select new players. Press any key to exit");
            if (int.TryParse(Console.ReadLine(), out selection))
            {
                if (selection == 1)
                    goto StartOfGame;
                if (selection == 2)
                    goto StartOfProgram;
            }
            
            
        }
    }
}
