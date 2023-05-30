using Assets.Scripts.UI.ViewModels.Interfaces;
using UnityEngine;

namespace Assets.Scripts.UI.Views
{
    public class GameScreenView : View<IGameScreenViewModel>
    {
        [SerializeField]
        private BarView _healthbar;

        protected override void InitInternal(IGameScreenViewModel viewModel)
        {
            _healthbar.Init(_viewModel.GetHealthBarViewModel());
        }

        protected override void Subscribe() { }
        protected override void Unsubscribe() { }

    }
}