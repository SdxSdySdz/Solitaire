using System.Collections.Generic;
using System.Linq;
using Solitaire.Model.GameLogic;
using UnityEngine;
using UnityEngine.Events;

namespace Solitaire.Presenters
{
    public class BoardPresenter : Presenter<Board>
    {
        [SerializeField] private CardsColumnPresenter _columnPrefab;
        [SerializeField] private HorizontalPlacer _placer;

        private List<CardsColumnPresenter> _columns;

        public event UnityAction<CardPresenter> CombinationMoveRequested;

        private IEnumerable<Transform> Transforms => _columns.Select(x => x.transform);

        protected override void OnInit()
        {
            _columns = new List<CardsColumnPresenter>();

            foreach (var column in Model.Columns)
            {
                CardsColumnPresenter columnPresenter = Instantiate(_columnPrefab, transform);
                columnPresenter.Init(column);
                _columns.Add(columnPresenter);
            }

            _placer.PlaceAsChilds(Transforms);
        }

        protected override void OnEnableAndNotNullModel()
        {
            foreach (var column in _columns)
            {
                column.VisibleCardClicked += OnVisibleCardClicked;
            }
        }

        protected override void OnDisableAndNotNullModel()
        {
            foreach (var column in _columns)
            {
                column.VisibleCardClicked -= OnVisibleCardClicked;
            }
        }

        private void OnVisibleCardClicked(CardPresenter card)
        {
            CombinationMoveRequested?.Invoke(card);
        }
    }
}
