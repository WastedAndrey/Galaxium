using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Components.CommandApplyers.Factories
{
    public class ReviveApplyerFactory : ComponentFactoryBase<ReviveApplyerComponent>
    {
        public ReviveApplyerFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}