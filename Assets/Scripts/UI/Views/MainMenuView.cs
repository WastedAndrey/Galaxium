using Assets.Scripts.ObjectManagement;
using Assets.Scripts.UI.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class MainMenuView : View<IMainMenuViewModel>
    {
        private ObjectManager _objectManager;
        [Header("Prefabs")]
        [SerializeField]
        private ButtonView _prefabLevelButton;
        [Header("Inner links")]
        [SerializeField]
        private Transform _levelButtonsParent;
        [SerializeField]
        private Button _exitButton;

        private Dictionary<ButtonView, int> _levelButtons = new Dictionary<ButtonView, int>();

        protected override void InitInternal(IMainMenuViewModel viewModel)
        {
            CreateButtons(viewModel.LevelsCount);
        }

        private void CreateButtons(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateButton(i);
            }
        }
        private void CreateButton(int buttonIndex)
        {
            ButtonView newButton = _objectManager.InstantiatePrefab<ButtonView>(_prefabLevelButton);
            newButton.Init(_viewModel.GetButtonViewModel(buttonIndex));
            newButton.Clicked += ButtonClicked;
            newButton.transform.SetParent(_levelButtonsParent);
            _levelButtons.Add(newButton, buttonIndex);
        }

        private void ButtonClicked(ButtonView button)
        {
            _viewModel.LevelButtonPressed(_levelButtons[button]);
        }
        protected override void OnDestroyInternal()
        {
            UnsubscribeFromButtons();
        }

        private void UnsubscribeFromButtons()
        {
            foreach (var button in _levelButtons.Keys.ToList())
            {
                button.Clicked -= ButtonClicked;
            }
        }
    }
}