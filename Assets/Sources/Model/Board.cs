using System;
using System.Collections.Generic;

namespace Assets.Sources.Model
{
    public class Board : ICopyable<Board>
    {
        private List<CardsColumn> _columns;

        public Board(int columnsCount)
        {
            _columns = new List<CardsColumn>(columnsCount);
            for (int i = 0; i < columnsCount; i++)
            {
                _columns.Add(new CardsColumn());
            }
        }

        private Board(List<CardsColumn> columns)
        {
            _columns = columns;
        }

        public void AddToColumn(Card card, int columnIndex)
        {
            if (0 > columnIndex || columnIndex >= _columns.Count)
                throw new ArgumentOutOfRangeException(nameof(columnIndex));

            _columns[columnIndex].Add(card);
        }

        public Board Copy()
        {
            List<CardsColumn> columnsCopy = new List<CardsColumn>(_columns.Count);
            foreach (var column in _columns)
            {
                columnsCopy.Add(column.Copy());
            }

            return new Board(columnsCopy);
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
   
