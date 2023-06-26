using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class DestroyApplyerFactory : ComponentFactoryBase<DestroyApplyerComponent>
    {
        public DestroyApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}