
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponFactories
{
   [CreateAssetMenu(fileName = "WeaponFactoryLazer", menuName = "Game/WeaponFactoryLazer")]
    public class WeaponFactoryLazer : WeaponFactoryBase
    {
        public override WeaponBase Create()
        {
            var newWeapon  = _diContainer.Instantiate<WeaponLazer>();
            newWeapon.Init(_settings);
            return newWeapon;
        }
    }
}