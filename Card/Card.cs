namespace Cards
{
    public class Card
    {
        public Card(CardSuite suite, CardFigure figure)
        {
            Suite = suite;
            Figure = figure;
            IsOpened = false;
        }

        public CardSuite Suite { get; set; }

        public CardFigure Figure { get; set; }

        public bool IsOpened { get; set; }

        public override bool Equals(object obj) => obj is Card && obj != null ? Equals((Card)obj) : false;

        public bool Equals(Card card) => card.Figure == Figure && card.Suite == Suite && card != null;

        public override string ToString() => $"{Figure} {Suite}!!!";

        public virtual void Visible(bool r) => IsOpened = r;

        public virtual void Rotate() => IsOpened = !IsOpened;

        public override int GetHashCode()
        {
            var hashCode = Suite.GetHashCode();
            hashCode = hashCode * -1521134295 + Figure.GetHashCode();
            return hashCode;
        }       
    }
}
