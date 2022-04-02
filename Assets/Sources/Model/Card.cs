using System;

namespace Assets.Sources.Model
{
    public class Card : ICopyable<Card>
    {
        private FaceValue _faceValue;
        private Suit _suit;
        private bool _isVisible;

        public Card(FaceValue faceValue, Suit suit) : this(faceValue, suit, false)
        {
        }

        private Card(FaceValue faceValue, Suit suit, bool isVisible)
        {
            _faceValue = faceValue;
            _suit = suit;
            _isVisible = isVisible;
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
            int facesCount = Enum.GetValues(typeof(FaceValue)).Length;
            int incrementedValue = ((int)_faceValue + 1) % facesCount;
            int decrementedValue = ((int)_faceValue - 1) % facesCount;
            int otherValue = (int)other._faceValue;

            if (incrementedValue == otherValue)
                return true;

            if (decrementedValue == otherValue)
                return true;

            return false;
        }

        public Card Copy()
        {
            return new Card(_faceValue, _suit, _isVisible);
        }
    }

    public enum FaceValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
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
