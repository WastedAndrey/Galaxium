using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class ResetApplyerFactory : ComponentFactoryBase<ResetApplyerComponent>
    {
        public ResetApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}