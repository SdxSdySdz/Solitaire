using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Sources.Model
{
    public class Board : ICopyable<Board>
    {
        private List<CardsColumn> _columns;

        public Board(int columnsCount)
        {
            _columns = new List<CardsColumn>(columnsCount);
        }

        private IEnumerable<Card> VisibleCards => _columns.Select(column => column.VisibleCard);

        public void AddToColumn(Card card, int columnIndex)
        {
            if (0 < columnIndex || columnIndex >= _columns.Count)
                throw new ArgumentOutOfRangeException(nameof(columnIndex));

            _columns[columnIndex].Add(card);
        }

        public Board Copy()
        {
            throw new NotImplementedException();
        }

        public bool TryRemove(Card card)
        {
            foreach (var column in _columns)
            {
                if (column.IsEmpty)
                    continue;

                if (card == column.VisibleCard)
                {
                    column.Pop();
                    return true;
                }
            }

            return false;
        }
    }
}
   
