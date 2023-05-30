
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class WeaponBase
    {
        protected WeaponSettings _settings;
        protected UnitTeam _team;
        protected float _shootCooldown = 0;

        public WeaponBase(WeaponSettings settings)
        {
            _settings = settings;
        }

        public abstract bool Shoot(Vector2 weaponPosition, Quaternion rotation, float attackDamage, UnitTeam team);

        public abstract void Update(float deltaTime, float attackSpeed);
    }
}