
namespace Assets.Scripts.UI.ViewModels.Interfaces
{
    public interface IMainMenuViewModel : IViewModel
    {
        int LevelsCount { get; }
        void LevelButtonPressed(int index);
        void ExitButtonPressed();
        IPropertyViewModel<string> GetButtonViewModel(int index);
    }
}