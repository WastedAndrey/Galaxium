using Assets.Scripts.UI.ViewModels.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class BarView : View<IPropertyViewModel<float>>
    {
        [SerializeField]
        private Image _fillImage;

        protected override void InitInternal(IPropertyViewModel<float> viewModel)
        {
            OnValueChange(viewModel.Property.Value);
        }

        protected override void Subscribe()
        {
            _viewModel.Property.Changed += OnValueChange;
        }

        protected override void Unsubscribe()
        {
            _viewModel.Property.Changed -= OnValueChange;
        }

        private void OnValueChange(float value)
        {
            _fillImage.fillAmount = value;
        }
    }
}