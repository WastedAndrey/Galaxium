
using Assets.Scripts.GameLevels;
using Assets.Scripts.UI;
using Assets.Scripts.UI.ViewModels;
using Assets.Scripts.UI.Views;

namespace Assets.Scripts.GameManagement.GameStates
{
    public class GameLevelState : GameStateBase
    {
        private GameScreenView _gameScreen;

        public GameLevelState(GameContext context) : base(context) { }

        protected override void EnterInternal()
        {
            LoadAssets();
        }

        private async void LoadAssets()
        {
            GameScreenViewModel gameScreenVM = new GameScreenViewModel();
            _gameScreen = await UIManager.Instance.OpenWindow<GameScreenView>(UIAddressablesConsts.GameScreen);
            _gameScreen.Init(gameScreenVM);
        }

        protected override void ExitInternal()
        {
            UIManager.Instance.CloseWindow(_gameScreen);
        }

        protected override void UpdateInternal(float deltaTime)
        {
        }
    }
}