using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    public class Card
    {
        private enum CardColor
        {
            Unassigned = -1,
            Red,
            Green,
            Blue,
            Yellow
        };

        public int Number { get; set; }
        public int Color { get; set; } //Red,Green,Blue,Yellow

        public Card(int number, int color)
        {
            Number = (number > 9 || number < 0 ? -1 : number);
            Color = (color > 3 || color < 0 ? -1 : color);
        }

        
    }
}
