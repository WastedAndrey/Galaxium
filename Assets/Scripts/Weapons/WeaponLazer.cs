
using Assets.Scripts.General;
using Assets.Scripts.Units;
using Assets.Scripts.Units.Missiles;
using Assets.VisualEffects;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponLazer : WeaponBase
    {
        public WeaponLazer(MissileFactory missileFactory, VisualEffectFactory visualEffectFactory) : base(missileFactory, visualEffectFactory)
        {

        }

        public override bool Shoot(Vector2 weaponPosition, Quaternion rotation, float attackDamage, UnitTeam team)
        {
            if (_shootCooldown <= 0)
            {
                _shootCooldown = _settings.AttackCooldown;

                Vector2 direction = GameMaths.DegreeToVector2(rotation.eulerAngles.z);
                Vector2 missilePosition = weaponPosition + direction;
                UnitBase missile = _missileFactory.Create(_settings.PrefabMissile, missilePosition, rotation, null, team);

                if (_settings.PrefabShootEffect != null)
                {
                    _visualEffectFactory.Create(_settings.PrefabShootEffect, missilePosition, rotation, null);
                }

                return true;
            }
            else
                return false;
        }

        public override void Update(float deltaTime, float attackSpeed)
        {
            if (_shootCooldown > 0)
            {
                _shootCooldown -= deltaTime * attackSpeed;
            }
        }
    }
}