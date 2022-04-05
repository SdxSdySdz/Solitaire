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
        int columnsCount = 1;
        int combinationsCount = 1;
        int minCombinationLength = 5;
        int maxCombinationLength = 5;
        float ascendingChance = 0.0f;
        float mirroringChance = 0.99f;
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
