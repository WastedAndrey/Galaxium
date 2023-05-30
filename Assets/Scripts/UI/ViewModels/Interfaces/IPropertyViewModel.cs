
using Assets.Scripts.General;
using System;

namespace Assets.Scripts.UI.ViewModels.Interfaces
{
    public interface IPropertyViewModel<T> : IViewModel
    {
        IReactivePropertyReadOnly<T> Property { get; }
    }
}