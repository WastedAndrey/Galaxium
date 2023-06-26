
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public abstract class ComponentFactoryWithSettingsBase<S, T> : IFactory<UnitBase, UnitContext, S, T> where T : UnitComponentBase
    {
        protected DiContainer _diContainer;

        [Inject]
        public ComponentFactoryWithSettingsBase(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create(UnitBase unit, UnitContext context, S settings)
        {
            var args = new object[] { unit, context, settings };
            return _diContainer.Instantiate<T>(args);
        }
    }
}