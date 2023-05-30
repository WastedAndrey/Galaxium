
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponFactories
{
   [CreateAssetMenu(fileName = "WeaponFactoryLazer", menuName = "Game/WeaponFactoryLazer")]
    public class WeaponFactoryLazer : WeaponFactoryBase
    {
        public override WeaponBase Create()
        {
            return new WeaponLazer(_settings);
        }
    }
}