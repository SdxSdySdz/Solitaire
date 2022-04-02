using System.Collections.Generic;

namespace Assets.Sources.Model
{
    public class CardsColumn : ICopyable<CardsColumn>
    {
        private LinkedList<Card> _cards;

        public CardsColumn() : this(new LinkedList<Card>())
        {
        }

        private CardsColumn(LinkedList<Card> cards)
        {
            _cards = cards;
        }

        public Card VisibleCard => _cards.Last.Value;
        public bool IsEmpty => _cards.Count == 0;

        public void Add(Card card)
        {
            if (IsEmpty == false)
                VisibleCard.Hide();

            _cards.AddLast(card);
            card.Show();
        }

        public CardsColumn Copy()
        {
            LinkedList<Card> cardsCopy = new LinkedList<Card>();
            foreach (Card card in _cards)
            {
                cardsCopy.AddLast(card.Copy());
            }

            return new CardsColumn(cardsCopy);
        }

        public Card Pop()
        {
            Card card = _cards.Last.Value;
            _cards.RemoveLast();

            if (IsEmpty == false)
                _cards.Last.Value.Show();

            return card;
        }
    }
}
