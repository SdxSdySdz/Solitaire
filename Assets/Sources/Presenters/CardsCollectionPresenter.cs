using System.Collections.Generic;
using Solitaire.Model.GameLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Solitaire.Presenters
{
    public abstract class CardsCollectionPresenter<TModel> : Presenter<TModel>
    where TModel : CardsCollection
    {
        [SerializeField] private CardPresenter _cardPrefab;
        [SerializeField] private Placer _placer;

        private List<CardPresenter> _cards;

        public event UnityAction<CardPresenter> VisibleCardClicked;

        protected List<CardPresenter> Cards => _cards;

        protected abstract IEnumerable<Transform> Transforms { get; }

        protected override void OnInit()
        {
            _cards = new List<CardPresenter>();

            foreach (var card in Model.Cards)
            {
                CardPresenter cardPresenter = Instantiate(_cardPrefab, transform);
                cardPresenter.Init(card);
                _cards.Add(cardPresenter);
            }

            _placer.PlaceAsChilds(Transforms);
        }

        protected override void OnEnableAndNotNullModel()
        {
            foreach (var card in _cards)
            {
                card.Clicked += OnCardClicked;
            }
        }

        protected override void OnDisableAndNotNullModel()
        {
            foreach (var card in _cards)
            {
                card.Clicked -= OnCardClicked;
            }
        }

        protected void OnCardClicked(CardPresenter card)
        {
            if (card.Model.IsVisible)
                VisibleCardClicked?.Invoke(card);
        }
    }
}
