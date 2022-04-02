using Assets.Sources.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardPresenter : Presenter<Board>
{
    [SerializeField] private CardsColumnPresenter _columnPrefab;
    [SerializeField] private HorizontalPlacer _placer;

    private List<CardsColumnPresenter> _columns;

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
}
