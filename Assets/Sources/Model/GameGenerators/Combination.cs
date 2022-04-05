using Solitaire.Model.GameLogic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire.Model.GameGenerators
{
    public class Combination : IEnumerable<Card>
    {
        private readonly Card _startCard;
        private readonly int _length;
        private readonly bool _isAscending;
        private readonly bool _isMirrored;

        public Combination(Card startCard, int length, bool isAscending, bool isMirrored)
        {
            _startCard = startCard;
            _length = length;
            _isAscending = isAscending;
            _isMirrored = isMirrored;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            Card card = _startCard;
            yield return card;

            if (_isMirrored)
            {
                for (int i = 0; i < _length / 2; i++)
                {
                    card = GetNeighborCard(card, _isAscending);
                    yield return card;
                }

                for (int i = _length / 2; i < _length - 1; i++)
                {
                    card = GetNeighborCard(card, _isAscending == false);
                    yield return card;
                }
            }
            else
            {
                for (int i = 0; i < _length - 1; i++)
                {
                    card = GetNeighborCard(card, _isAscending);
                    yield return card;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Card GetNeighborCard(Card card, bool isAscending)
        {
            int offset = isAscending ? 1 : -1;
            int faceValuesCount = Enum.GetValues(typeof(FaceValue)).Length;

            FaceValue faceValue = (FaceValue)(((int)card.FaceValue + offset + faceValuesCount) % faceValuesCount);
            Suit suit = Suit.Worms;
          
            return new Card(faceValue, suit);
        }
    }
}
