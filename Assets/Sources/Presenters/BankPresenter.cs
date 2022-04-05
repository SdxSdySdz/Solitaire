using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Solitaire.Model.GameLogic;
using UnityEngine;

namespace Solitaire.Presenters
{
    public class BankPresenter : CardsCollectionPresenter<Bank>
    {
        [SerializeField] private Transform _combinationStartPoint;

        protected override IEnumerable<Transform> Transforms => Cards.Select(card => card.transform).SkipLast(1);

        public void PlaceAtCombinationStart(CardPresenter card)
        {
            RemoveLastCard();

            Cards.Add(card);
            card.Clicked += OnCardClicked;

            card.transform.DOMove(_combinationStartPoint.position, .5f);
        }

        protected override void OnInit()
        {
            base.OnInit();
            Cards.Last().transform.position = _combinationStartPoint.position;
        }

        protected override void OnEnableAndNotNullModel()
        {
            base.OnEnableAndNotNullModel();
            Model.NextCardSet += OnNextCardSet;
        }

        protected override void OnDisableAndNotNullModel()
        {
            base.OnDisableAndNotNullModel();
            Model.NextCardSet -= OnNextCardSet;
        }

        private void OnNextCardSet()
        {
            RemoveLastCard();

            Cards[Cards.Count - 1].transform.DOMove(_combinationStartPoint.position, .5f);
        }

        private void RemoveLastCard()
        {
            int lastIndex = Cards.Count - 1;
            Cards[lastIndex].Clicked -= OnCardClicked;
            Destroy(Cards[lastIndex].gameObject);
            Cards.RemoveAt(lastIndex);
        }
    }
}