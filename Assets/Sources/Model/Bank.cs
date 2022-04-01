using System;
using System.Collections.Generic;

namespace Assets.Sources.Model
{
    public class Bank : ICopyable<Bank>
    {
        private List<Card> _cards;

        public Card VisibleCard => _cards[_cards.Count - 1];

        public void Add(Card card)
        {
            _cards[_cards.Count - 1].Hide();
            _cards.Add(card);
            card.Show();
        }

        public Bank Copy()
        {
            Bank copy = new Bank();
            copy._cards = new List<Card>(_cards);
            return copy;
        }

        public bool TrySetNextCard()
        {
            throw new NotImplementedException();
        }
    }
}
