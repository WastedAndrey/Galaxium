
using Assets.Scripts.GameManagement;
using Assets.Scripts.General;
using Assets.Scripts.UI.ViewModels.Interfaces;

namespace Assets.Scripts.UI.ViewModels
{
    public class MainMenuViewModel : IMainMenuViewModel
    {
        private GameSettings _settings;
        public int LevelsCount => _settings.GameLevelSettings.Count;

        public MainMenuViewModel(GameSettings settings)
        {
            _settings = settings;
        }

        public void ExitButtonPressed()
        {
            throw new System.NotImplementedException();
        }

        public void LevelButtonPressed(int index)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {

        }

        public IPropertyViewModel<string> GetButtonViewModel(int index)
        {
            return new PropertyViewModel<string>($"Level {index}");
        }
    }
}