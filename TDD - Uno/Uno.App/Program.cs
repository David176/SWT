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
            Deck deck = new Deck(new CardRules(9,0,4));
            UnoGame unoGame = new UnoGame(deck);

            unoGame.AddPlayer(new Player(unoGame, "Jens"));
            unoGame.AddPlayer(new Player(unoGame, "Hans"));
            unoGame.AddPlayer(new Player(unoGame, "Joachim"));

            unoGame.StartGame();
        }
    }
}
