using System;
using System.Collections.Generic;

namespace Assets.Sources.Model
{
    public class CardsColumn : ICopyable<CardsColumn>
    {
        private LinkedList<Card> _cards;

        public Card VisibleCard => _cards.Last.Value;

        public bool IsEmpty => _cards.Count == 0;

        public void Add(Card card)
        {
            VisibleCard.Hide();
            _cards.AddLast(card);
            card.Show();
        }

        public CardsColumn Copy()
        {
            CardsColumn copy = new CardsColumn();
            copy._cards = new LinkedList<Card>();
            return copy;
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
