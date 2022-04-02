using Assets.Sources.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CardsColumnPresenter : Presenter<CardsColumn>
{
    [SerializeField] private CardPresenter _cardPrefab;

    private List<CardPresenter> _cards = new List<CardPresenter>();

    protected override void OnInit()
    {
        foreach (var card in Model.Cards)
        {
            CardPresenter cardPresenter = Instantiate(_cardPrefab, transform);
            cardPresenter.Init(card);
            _cards.Add(cardPresenter);
        }

        PlaceCards();
    }

    private void PlaceCards()
    {
        Vector2 offset = Vector2.zero;
        foreach (var card in _cards)
        {
            card.transform.position = transform.position + (Vector3)offset;
            offset += Vector2.down;
        }
    }
}
