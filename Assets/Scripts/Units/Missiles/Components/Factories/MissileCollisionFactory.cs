using Assets.Scripts.Units.Components.Factories;
using Zenject;

namespace Assets.Scripts.Units.Missiles.Components.Factories
{
    public class MissileCollisionFactory : ComponentFactoryBase<MissileCollisionComponent>
    {
        public MissileCollisionFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}