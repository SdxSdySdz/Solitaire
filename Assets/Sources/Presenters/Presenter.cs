using Assets.Sources.Model;
using UnityEngine;

public abstract class Presenter<TModel> : MonoBehaviour 
    // where TModel : Transformable
{
    private TModel _model;

    public TModel Model => _model;

/*    private void OnEnable()
    {
        _model.Moved += OnMoved;
        _model.Rotated += OnRotated;
        _model.Destroying += OnDestroying;
    }

    private void OnDisable()
    {
        _model.Moved -= OnMoved;
        _model.Rotated -= OnRotated;
        _model.Destroying -= OnDestroying;
    }*/

    public void Init(TModel model)
    {
        _model = model;
        enabled = true;

        OnInit();
        // _model.MoveTo(transform.position);
    }

    protected virtual void OnInit() 
    {
        // _model.MoveTo(transform.position);
    }
/*
    private void OnMoved()
    {
        transform.position = _model.Position;
    }

    private void OnRotated()
    {
        transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
    }

    private void OnDestroying()
    {
        Destroy(gameObject);
    }
*/
}
