using Assets.Sources.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardsColumnPresenter : Presenter<CardsColumn>
{
    [SerializeField] private CardPresenter _cardPrefab;
    [SerializeField] private Placer _placer;

    private List<CardPresenter> _cards = new List<CardPresenter>();

    private IEnumerable<Transform> Transforms => _cards.Select(x => x.transform);

    protected override void OnInit()
    {
        foreach (var card in Model.Cards)
        {
            CardPresenter cardPresenter = Instantiate(_cardPrefab, transform);
            cardPresenter.Init(card);
            _cards.Add(cardPresenter);
        }

        _placer.PlaceAsChilds(Transforms);
    }
}
