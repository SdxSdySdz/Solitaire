using Solitaire.Model.Exceptions;
using Solitaire.Model.GameLogic;
using Solitaire.Model.GameLogic.Moves;
using UnityEngine;

namespace Solitaire.Presenters
{
    public class GamePresenter : Presenter<GameState>
    {
        [SerializeField] private BankPresenter _bank;
        [SerializeField] private BoardPresenter _board;

        protected override void OnInit()
        {
            _bank.Init(Model.Bank);
            _board.Init(Model.Board);
        }

        protected override void OnEnableAndNotNullModel()
        {
            _bank.VisibleCardClicked += OnBankMoveRequested;
            _board.CombinationMoveRequested += OnCombinationMoveRequested;
        }

        protected override void OnDisableAndNotNullModel()
        {
            _bank.VisibleCardClicked -= OnBankMoveRequested;
            _board.CombinationMoveRequested -= OnCombinationMoveRequested;
        }

        private void OnBankMoveRequested(CardPresenter card)
        {
            try
            {
                Model.Apply(new BankMove());
            }
            catch (InvalidMoveException)
            {
                Debug.LogError("Invalid move");
            }
        }

        private void OnCombinationMoveRequested(CardPresenter card)
        {
            try
            {
                Model.Apply(new CombinationMove(card.Model));
                _bank.PlaceAtCombinationStart(card);
            }
            catch (InvalidMoveException)
            {
                Debug.LogError("Invalid move");
            }
        }
    }
}
