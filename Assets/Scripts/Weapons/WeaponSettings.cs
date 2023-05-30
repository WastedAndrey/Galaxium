using Assets.Scripts.Units;
using Assets.Scripts.Units.Missiles;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    [System.Serializable]
    public class WeaponSettings
    {
        [SerializeField]
        private UnitBase _prefabMissile;
        [SerializeField]
        private UnitBase _prefabShootEffect;
        [SerializeField]
        private float _attackCooldown;

        public UnitBase PrefabMissile { get => _prefabMissile; }
        public UnitBase PrefabShootEffect { get => _prefabShootEffect; }
        public float AttackCooldown { get => _attackCooldown; }
    }
}