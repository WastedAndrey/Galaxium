
using Assets.Scripts.ObjectManagement;
using Assets.Scripts.UI;
using Assets.Scripts.UI.ViewModels;
using Assets.Scripts.UI.ViewModels.Interfaces;
using Assets.Scripts.UI.Views;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameManagement.GameStates
{
    public class MainMenuState : GameStateBase
    {
        public MainMenuState(GameContext context) : base(context) { }

        private MainMenuView _mainMenu;

        protected override void EnterInternal()
        {
            LoadAssets();
            LoadScene();
        }

        private async void LoadAssets()
        {
            MainMenuViewModel mainMenuVM = new MainMenuViewModel(_context.Settings);
            _mainMenu = await UIManager.Instance.OpenWindow<MainMenuView>(UIAddressablesConsts.MainMenu);
            _mainMenu.Init(mainMenuVM);
        }

        private async void LoadScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_context.Settings.MainMenuSceneName);
        }

        protected override void ExitInternal()
        {
            UIManager.Instance.CloseWindow(_mainMenu);
        }

        protected override void UpdateInternal(float deltaTime)
        {
           
        }
    }
}