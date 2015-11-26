namespace Uno
{
    public class CardRules
    {
        public int HighestNumber;
        public int LowestNumber;
        public int AmountOfColors;

        public CardRules(int highestNumber, int lowestNumber, int amountOfColors)
        {
            HighestNumber = highestNumber;
            LowestNumber = lowestNumber;
            AmountOfColors = amountOfColors;
        }
    }
}