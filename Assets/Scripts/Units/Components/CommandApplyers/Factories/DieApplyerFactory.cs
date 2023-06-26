using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class DieApplyerFactory : ComponentFactoryBase<DieApplyerComponent>
    {
        public DieApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}