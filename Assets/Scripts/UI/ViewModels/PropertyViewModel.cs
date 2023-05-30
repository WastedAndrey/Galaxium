
using Assets.Scripts.General;
using Assets.Scripts.UI.ViewModels.Interfaces;

namespace Assets.Scripts.UI.ViewModels
{
    public class PropertyViewModel<T> : IPropertyViewModel<T>
    {
        private ReactiveProperty<T> _property;
        public IReactivePropertyReadOnly<T> Property => _property;

        public PropertyViewModel(T value)
        {
            _property = new ReactiveProperty<T>(value);
        }

        public void Dispose()
        {
            _property.Dispose();
        }
    }
}