
using Assets.Scripts.Units;
using Assets.Scripts.Units.Missiles;
using Assets.VisualEffects;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Weapons
{
    public abstract class WeaponBase
    {
        protected readonly MissileFactory _missileFactory;
        protected readonly VisualEffectFactory _visualEffectFactory;
        protected WeaponSettings _settings;
        protected float _shootCooldown = 0;

        [Inject]
        public WeaponBase(MissileFactory missileFactory, VisualEffectFactory visualEffectFactory)
        {
            _missileFactory = missileFactory;
            _visualEffectFactory = visualEffectFactory;
        }

        public virtual void Init(WeaponSettings settings)
        {
            _settings = settings;
        }

        public abstract bool Shoot(Vector2 weaponPosition, Quaternion rotation, float attackDamage, UnitTeam team);

        public abstract void Update(float deltaTime, float attackSpeed);
    }
}