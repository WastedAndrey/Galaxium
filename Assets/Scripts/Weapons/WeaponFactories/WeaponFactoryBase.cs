using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons.WeaponFactories
{
    public abstract class WeaponFactoryBase : ScriptableObject
    {
        [Inject]
        protected DiContainer _diContainer;

        [SerializeField]
        protected WeaponSettings _settings;
        public abstract WeaponBase Create();
    }
}

