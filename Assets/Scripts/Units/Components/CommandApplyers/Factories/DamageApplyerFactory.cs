
using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class DamageApplyerFactory : ComponentFactoryBase<DamageApplyerComponent>
    {
        public DamageApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}