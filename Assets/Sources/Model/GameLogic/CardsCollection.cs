using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Model.GameLogic
{
    public abstract class CardsCollection
    {
        protected LinkedList<Card> _cards; //

        protected CardsCollection(LinkedList<Card> cards)
        {
            _cards = cards;
        }

        public Card VisibleCard => _cards.Last.Value; //
        public IEnumerable<Card> Cards => _cards.Select(card => card);  //
        public bool IsEmpty => _cards.Count == 0;  //

        public event Action<Card> CardRemoved; //

        public void Add(Card card)  //
        {
            if (IsEmpty == false)
                VisibleCard.Hide();

            _cards.AddLast(card);
            card.Show();
        }

        protected void InvokeCardRemoved(Card card)
        {
            CardRemoved?.Invoke(card);
        }

        protected LinkedList<Card> CopyCards()
        {
            LinkedList<Card> cardsCopy = new LinkedList<Card>();
            foreach (Card card in _cards)
            {
                cardsCopy.AddLast(card.Copy());
            }

            return cardsCopy;
        }
    }
}
