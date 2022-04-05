using System;
using System.Collections.Generic;

namespace Solitaire.Model.GameLogic
{
    public class Bank : CardsCollection, ICopyable<Bank>
    {
        private Bank(LinkedList<Card> cards) : base(cards)
        {
        }

        public Bank() : this(new LinkedList<Card>())
        {
        }

        public event Action NextCardSet;

        public Bank Copy()
        {
            return new Bank(CopyCards());
        }

        public bool TrySetNextCard()
        {
            if (_cards.Count < 2)
                return false;

            InvokeCardRemoved(VisibleCard);
            _cards.RemoveLast();

            VisibleCard.Show();
            NextCardSet?.Invoke();
            return true;
        }

        public void ReplaceAsVisible(Card card)
        {
            _cards.Last.Value = card;
            card.Show();
        }
    }
}
