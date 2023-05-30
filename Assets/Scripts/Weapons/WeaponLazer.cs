
using Assets.Scripts.General;
using Assets.Scripts.ObjectManagement;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class WeaponLazer : WeaponBase
    {
        public WeaponLazer(WeaponSettings settings) : base (settings)
        {
           
        }

        public override bool Shoot(Vector2 weaponPosition, Quaternion rotation, float attackDamage, UnitTeam team)
        {
            if (_shootCooldown <= 0)
            {
                _shootCooldown = _settings.AttackCooldown;

                Vector2 direction = GameMaths.DegreeToVector2(rotation.eulerAngles.z); 
                Vector2 missilePosition = weaponPosition + direction;
                UnitBase missile = ObjectManager.Instanse.InstantiatePrefab(_settings.PrefabMissile, missilePosition, rotation);
                missile.SetUnitTeam(team);


                if (_settings.PrefabShootEffect != null)
                {
                    ObjectManager.Instanse.InstantiatePrefab(_settings.PrefabShootEffect, missilePosition, rotation);
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