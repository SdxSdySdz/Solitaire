using System.Collections.Generic;

namespace Solitaire.Model.GameLogic
{
    public class CardsColumn : CardsCollection, ICopyable<CardsColumn>
    {
        public CardsColumn() : this(new LinkedList<Card>())
        {
        }

        private CardsColumn(LinkedList<Card> cards) : base(cards)
        {
        }

        public CardsColumn Copy()
        {
            return new CardsColumn(CopyCards());
        }

        public Card Pop()
        {
            Card card = _cards.Last.Value;
            _cards.RemoveLast();

            if (IsEmpty == false)
                _cards.Last.Value.Show();

            InvokeCardRemoved(card);
            return card;
        }
    }
}
