using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class TeamApplyerFactory : ComponentFactoryBase<TeamApplyerComponent>
    {
        public TeamApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}