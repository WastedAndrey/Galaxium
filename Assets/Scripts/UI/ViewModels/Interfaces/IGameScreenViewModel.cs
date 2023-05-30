
using Assets.Scripts.UI.Views;

namespace Assets.Scripts.UI.ViewModels.Interfaces
{
    public interface IGameScreenViewModel : IViewModel
    {
        IPropertyViewModel<float> GetHealthBarViewModel();
    }
}