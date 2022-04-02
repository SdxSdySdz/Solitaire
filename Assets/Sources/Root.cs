using Assets.Sources.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private GamePresenter _gamePresenter;

    private Bank _bank;
    private Board _board;
    private GameState _game;

    private static System.Random _random = new System.Random(42);
    private static T Random<T>()
    {
        var values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(_random.Next(values.Length));
    }

    private static Card RandomCard => new Card(Random<FaceValue>(), Random<Suit>());

    private void Awake()
    {
        _bank = new Bank();
        var bankCards = new List<Card>()
        {
            new Card(FaceValue.Ace, Random<Suit>()),
            new Card(FaceValue.Jack, Random<Suit>()),
            new Card(FaceValue.Eight, Random<Suit>()),
            new Card(FaceValue.Five, Random<Suit>()),
            new Card(FaceValue.Two, Random<Suit>()),
            new Card(FaceValue.Ace, Random<Suit>()),
        };
        foreach (var card in bankCards)
        {
            _bank.Add(card);
        }

        int columnsCount = 3;
        _board = new Board(columnsCount);
        for (int column = 0; column < columnsCount; column++)
        {
            for (int i = 0; i < 3; i++)
            {
                _board.AddToColumn(RandomCard, column);
            }
        }

        _game = GameState.CreateNewGame(_bank, _board);

        _gamePresenter.Init(_game);
    }
}
