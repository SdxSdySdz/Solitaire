using System.Collections.Generic;
using System.Linq;
using Solitaire.Model.GameLogic;
using UnityEngine;

namespace Solitaire.Presenters
{
    public class CardsColumnPresenter : CardsCollectionPresenter<CardsColumn>
    {
        protected override IEnumerable<Transform> Transforms => Cards.Select(card => card.transform);

        protected override void OnEnableAndNotNullModel()
        {
            base.OnEnableAndNotNullModel();
            Model.CardRemoved += OnCardRemoved;
        }

        protected override void OnDisableAndNotNullModel()
        {
            base.OnDisableAndNotNullModel();
            Model.CardRemoved -= OnCardRemoved;
        }

        private void OnCardRemoved(Card card)
        {
            CardPresenter cardPresenter = Cards.First(presenter => presenter.Model == card);
            cardPresenter.Clicked -= OnCardClicked;
            Cards.Remove(cardPresenter);
        }
    }
}
