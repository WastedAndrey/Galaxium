using Assets.Scripts.UI.ViewModels.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class ButtonView : View<IPropertyViewModel<string>>
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _textMesh;

        public event UnityAction<ButtonView> Clicked;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick() => Clicked?.Invoke(this);

        protected override void OnDestroyInternal()
        {
            _button.onClick.RemoveAllListeners();
            Clicked = null;
        }

        protected override void InitInternal(IPropertyViewModel<string> viewModel)
        {
            TextChanged(_viewModel.Property.Value);
        }

        protected override void Subscribe()
        {
            _viewModel.Property.Changed += TextChanged;
        }

        protected override void Unsubscribe()
        {
            _viewModel.Property.Changed -= TextChanged;
        }

        private void TextChanged(string text)
        {
            _textMesh.text = text;
        }
    }
}