
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public abstract class ComponentFactoryBase<T> : IFactory<UnitBase, UnitContext, T> where T : UnitComponentBase
    {
        protected DiContainer _diContainer;

        [Inject]
        public ComponentFactoryBase(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create(UnitBase unit, UnitContext context)
        {
            var args = new object[] { unit, context };
            return _diContainer.Instantiate<T>(args);
        }
    }
}