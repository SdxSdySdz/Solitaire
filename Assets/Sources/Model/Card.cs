using System;

namespace Assets.Sources.Model
{
    public struct Card
    {
        private FaceValue _faceValue;
        private Suit _suit;
        private bool _isVisible;

        public Card(FaceValue faceValue, Suit suit)
        {
            _faceValue = faceValue;
            _suit = suit;
            _isVisible = false;
        }

        public static bool operator==(Card a, Card b)
        {
            return a._faceValue == b._faceValue && a._suit == b._suit;
        }

        public static bool operator!=(Card a, Card b)
        {
            return a._faceValue != b._faceValue || a._suit != b._suit;
        }

        public void Show()
        {
            _isVisible = true;
        }

        public void Hide()
        {
            _isVisible = false;
        }

        public bool IsNeighbor(Card other)
        {
            return Math.Abs(_faceValue - other._faceValue) == 1;
        }
    }

    public enum FaceValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Jack,
        Queen,
        King,
        Ace,
    }

    public enum Suit
    {
        Spades,
        Worms,
        Booby,
        Crosses,
    }
}
