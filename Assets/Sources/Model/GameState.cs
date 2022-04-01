using Assets.Sources.Model.Exceptions;
using System;

namespace Assets.Sources.Model
{
    public class GameState
    {
        private Bank _bank;
        private Board _board;
        private IMove _lastMove;
        private GameState _previousState;

        private GameState(Bank bank, Board board, IMove lastMove, GameState previousState)
        {
            _bank = bank;
            _board = board;
            _lastMove = lastMove;
            _previousState = previousState;
        }

        public static GameState CreateNewGame(Bank bank, int columnsCount)
        {
            return new GameState(bank, new Board(columnsCount), null, null);
        }

        public GameState Apply(BankMove move)
        {
            Bank bank = _bank.Copy();
            Board board = _board.Copy();

            if (bank.TrySetNextCard() == false)
                throw new InvalidMoveException();

            return new GameState(bank, board, move, this);
        }

        public GameState Apply(CombinationMove move)
        {
            if (move.Card.IsNeighbor(_bank.VisibleCard) == false)
                throw new InvalidMoveException();

            Bank bank = _bank.Copy();
            Board board = _board.Copy();

            if (board.TryRemove(move.Card) == false)
                throw new InvalidMoveException();

            return new GameState(bank, board, move, this);
        }
    }
}
