using Assets.Sources.Model;
using UnityEngine;

public class GamePresenter : Presenter<GameState>
{
    [SerializeField] private BankPresenter _bank;
    [SerializeField] private BoardPresenter _board;

    protected override void OnInit()
    {
        _bank.Init(Model.Bank);
        _board.Init(Model.Board);
    }
}
