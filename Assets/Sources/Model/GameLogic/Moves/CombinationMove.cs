namespace Solitaire.Model.GameLogic.Moves
{
    public struct CombinationMove : IMove
    {
        public CombinationMove(Card card)
        {
            Card = card;
        }

        public Card Card { get; private set; }
    }
}
