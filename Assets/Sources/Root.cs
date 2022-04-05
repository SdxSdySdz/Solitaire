using Solitaire.Model.GameGenerators;
using Solitaire.Model.GameLogic;
using Solitaire.Presenters;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private GamePresenter _gamePresenter;

    private GameState _game;

    private void Awake()
    {
        int columnsCount = 4;
        int combinationsCount = 5;
        int minCombinationLength = 2;
        int maxCombinationLength = 7;
        float ascendingChance = 0.65f;
        float mirroringChance = 0.13f;
        _game = new CombinationBasedGenerator(
            columnsCount,
            combinationsCount,
            minCombinationLength,
            maxCombinationLength,
            ascendingChance,
            mirroringChance)
            .Generate();

        _gamePresenter.Init(_game);
    }
}
