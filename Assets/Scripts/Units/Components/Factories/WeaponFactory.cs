
using Assets.Scripts.Weapons;
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public class WeaponFactory : ComponentFactoryWithSettingsBase<WeaponBase, WeaponComponent>
    {
        public WeaponFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}