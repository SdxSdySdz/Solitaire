using System.Collections.Generic;

namespace Assets.Sources.Model
{
    public class Bank : ICopyable<Bank>
    {
        private List<Card> _cards;

        public Bank() : this(new List<Card>())
        {
        }

        private Bank(List<Card> cards)
        {
            _cards = cards;
        }

        public Card VisibleCard => _cards[_cards.Count - 1];
        public bool IsEmpty => _cards.Count == 0;

        public void Add(Card card)
        {
            if (IsEmpty == false)
                VisibleCard.Hide();

            _cards.Add(card);
            card.Show();
        }

        public Bank Copy()
        {
            List<Card> cardsCopy = new List<Card>(_cards.Count);
            foreach (Card card in _cards)
            {
                cardsCopy.Add(card.Copy());
            }

            return new Bank(cardsCopy);
        }

        public bool TrySetNextCard()
        {
            if (_cards.Count < 2)
                return false;

            _cards.RemoveAt(_cards.Count - 1);
            _cards[_cards.Count - 1].Show();
            return true;
        }

        public void ReplaceAsVisible(Card card)
        {
            _cards[_cards.Count - 1] = card;
            card.Show();
        }
    }
}
