
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public class RotateModelFactory : ComponentFactoryBase<RotateModelComponent>
    {
        public RotateModelFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}