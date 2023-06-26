
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public class LimitedTimeFactory : ComponentFactoryWithSettingsBase<float, LimitedTimeComponent>
    {
        public LimitedTimeFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}