using Assets.Sources.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardPresenter : Presenter<Board>
{
    [SerializeField] private CardsColumnPresenter _columnPrefab;

    private List<CardsColumnPresenter> _columns;

    protected override void OnInit()
    {
        _columns = new List<CardsColumnPresenter>();

        foreach (var column in Model.Columns)
        {
            CardsColumnPresenter columnPresenter = Instantiate(_columnPrefab, transform);
            columnPresenter.Init(column);
            _columns.Add(columnPresenter);
        }

        PlaceColumns();
    }

    private void PlaceColumns()
    {
        Vector2 offset = Vector2.zero;
        foreach (var column in _columns)
        {
            column.transform.position = transform.position + (Vector3)offset;
            offset += Vector2.right;
        }
    }
}
