using System.Collections.Generic;
using UnityEngine;

public abstract class Placer : MonoBehaviour
{
    public void PlaceAsChilds(IEnumerable<Transform> transforms)
    {
        Place(transforms, transform);
    }

    public abstract void Place(IEnumerable<Transform> transforms, Transform parent);
}
