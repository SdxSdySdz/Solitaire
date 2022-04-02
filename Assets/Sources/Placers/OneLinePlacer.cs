using System.Collections.Generic;
using UnityEngine;

public abstract class OneLinePlacer : Placer
{
    [SerializeField] private float _distanceBetween;

    protected abstract Vector2 Direction { get; }

    public override void Place(IEnumerable<Transform> transforms, Transform parent)
    {
        Vector2 offset = Vector2.zero;
        Vector2 direction = Direction.normalized;
        foreach (var item in transforms)
        {
            item.position = parent.position + (Vector3)offset;
            item.SetParent(parent);

            offset += direction * _distanceBetween;
        }
    }
}
