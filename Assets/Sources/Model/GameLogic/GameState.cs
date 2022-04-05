using Solitaire.Model.Exceptions;
using Solitaire.Model.GameLogic.Moves;

namespace Solitaire.Model.GameLogic
{
    public class GameState : ICopyable<GameState>
    {
        private Bank _bank;
        private Board _board;
        private IMove _lastMove;

        private GameState(Bank bank, Board board, IMove lastMove)
        {
            _bank = bank;
            _board = board;
            _lastMove = lastMove;
        }

        public Bank Bank => _bank;
        public Board Board => _board;

        public static GameState CreateNewGame(Bank bank, Board board)
        {
            return new GameState(bank, board, null);
        }

        public void Apply(BankMove move)
        {
            if (_bank.TrySetNextCard() == false)
                throw new InvalidMoveException();
        }

        public void Apply(CombinationMove move)
        {
            if (move.Card.IsNeighbor(_bank.VisibleCard) == false)
                throw new InvalidMoveException();

            if (_board.TryRemove(move.Card) == false)
                throw new InvalidMoveException();

            _bank.ReplaceAsVisible(move.Card);
        }

        public GameState Copy()
        {
            return new GameState(_bank.Copy(), _board.Copy(), _lastMove);
        }
    }
}
