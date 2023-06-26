using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class MovementApplyerFactory : ComponentFactoryBase<MovementApplyerComponent>
    {
        public MovementApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}