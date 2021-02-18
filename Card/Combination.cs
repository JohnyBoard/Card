using Cards;
using System.Linq;

namespace GardGame
{
    public class Combination
    { 
        public int Pair(CardSet cards)
        {
            cards.Sort();
            int max = 1, r;
            foreach (var card in cards.Cards)
            {
                r = cards.Cards.Count(c => c.Figure == card.Figure);
                max = r > max ? r : max;
            }
            return max; 
        }

        public bool IsOnePair(CardSet cards) => Pair(cards) == 2;

        public bool IsSet(CardSet cards) => Pair(cards) == 3;

        public bool IsQuads(CardSet cards) => Pair(cards) == 4;

        public bool IsFlush(CardSet cards)
        {
            cards.Sort();
            int max = 1, r;
            foreach (var card in cards.Cards)
            {
                r = cards.Cards.Count(c => c.Suite == card.Suite);
                max = r > max ? r : max;
            }
            return max == 5;
        }

        public bool IsStraight(CardSet cards)
        {
            int r = 0;
            foreach (var card in cards.Cards)
            {
                r = cards.Cards.Count(c => c.Figure == c.Figure + 1);
            }
            return r == 5;
        }

        public bool IsStraightFlush(CardSet cards) => IsStraight(cards) && IsFlush(cards);

        public bool IsRoyalFlash(CardSet cards) => cards[0].Figure > CardFigure.nine && IsStraightFlush(cards);
    }
}
