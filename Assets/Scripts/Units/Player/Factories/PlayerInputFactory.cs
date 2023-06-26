using Zenject;
using Assets.Scripts.Units.Components.Factories;
using Assets.Scripts.Units.Components;

namespace Assets.Scripts.Units.Player.Factories
{
    public class PlayerInputFactory : ComponentFactoryWithSettingsBase<WeaponComponent, PlayerInputComponent>
    {
        public PlayerInputFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}