using UnityEngine;


namespace Assets.Scripts.Weapons.WeaponFactories
{
    public abstract class WeaponFactoryBase : ScriptableObject
    {
        [SerializeField]
        protected WeaponSettings _settings;
        public abstract WeaponBase Create();
    }
}

