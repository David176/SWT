using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    public class Card
    {
        public enum CardColor
        {
            Unassigned = -1,
            Red,
            Green,
            Blue,
            Yellow,
            Orange,
            White,
            Black,
            Purple
        };

        private CardRules _cardRules;

        public int Number { get; set; }
        public CardColor Color { get; set; } //Red,Green,Blue,Yellow

        public Card(int number, int color, CardRules cardRules)
        {
            _cardRules = cardRules;
            Number = (number > _cardRules.HighestNumber || number < _cardRules.LowestNumber ? -1 : number);
            Color = (CardColor) (color > _cardRules.AmountOfColors-1 || color < 0 ? -1 : color);
        }

        
    }
}
