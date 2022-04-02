using Assets.Sources.Model;
using System.Collections.Generic;
using UnityEngine;

public class BankPresenter : Presenter<Bank>
{
    [SerializeField] private CardPresenter _cardPrefab;

    private List<CardPresenter> _cards;

    protected override void OnInit()
    {
        Debug.LogError("Bank on init");
        _cards = new List<CardPresenter>();

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
            offset += Vector2.right;
        }
    }
}
