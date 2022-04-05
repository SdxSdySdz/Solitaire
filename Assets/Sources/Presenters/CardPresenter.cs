using Solitaire.Model.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solitaire.Presenters
{
    public class CardPresenter : Presenter<Card>, IPointerDownHandler
    {
        [SerializeField] private Sprite _visibleSprite;
        [SerializeField] private Sprite _hiddenSprite;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _faceText;
        [SerializeField] private TMP_Text _suitText;

        public event UnityAction<CardPresenter> Clicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            Clicked?.Invoke(this);
        }

        protected override void OnInit()
        {
            _faceText.text = Model.FaceValue.ToString();
            _suitText.text = Model.Suit.ToString();

            if (Model.IsVisible)
                OnShowed();
            else
                OnHided();
        }

        protected override void OnEnableAndNotNullModel()
        {
            Model.Showed += OnShowed;
            Model.Hided += OnHided;
        }

        protected override void OnDisableAndNotNullModel()
        {
            Model.Showed -= OnShowed;
            Model.Hided -= OnHided;
        }

        private void OnShowed()
        {
            OnTurnedOver(isFaceUp: true);
        }

        private void OnHided()
        {
            OnTurnedOver(isFaceUp: false);
        }

        private void OnTurnedOver(bool isFaceUp)
        {
            _image.sprite = isFaceUp ? _visibleSprite : _hiddenSprite;
            _faceText.gameObject.SetActive(isFaceUp);
            _suitText.gameObject.SetActive(isFaceUp);
        }
    }
}
