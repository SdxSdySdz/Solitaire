using UnityEngine;

namespace Solitaire.Presenters
{
    public abstract class Presenter<TModel> : MonoBehaviour
    {
        private TModel _model;

        public TModel Model => _model;

        protected void OnEnable()
        {
            if (_model != null)
                OnEnableAndNotNullModel();
        }

        protected void OnDisable()
        {
            if (_model != null)
                OnDisableAndNotNullModel();
        }

        public void Init(TModel model)
        {
            _model = model;
            OnInit();

            enabled = true;
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnEnableAndNotNullModel()
        {
        }

        protected virtual void OnDisableAndNotNullModel()
        {
        }
    }
}
