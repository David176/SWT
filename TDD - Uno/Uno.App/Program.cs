using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.App
{
    class Program
    {
        static void Main(string[] args)
        {
            CardRules cardRules = new CardRules(9,0,4);
            ConsoleWriter consoleWriter = new ConsoleWriter();
            Deck deck = new Deck(consoleWriter, cardRules);
            TableDeck tableDeck = new TableDeck();
            UnoGame unoGame = new UnoGame(tableDeck, deck, cardRules);

            unoGame.AddPlayer(new Player(unoGame, "Jens"));
            unoGame.AddPlayer(new Player(unoGame, "Hans"));

            unoGame.StartGame();
        }
    }
}
