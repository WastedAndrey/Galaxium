﻿
using Assets.Scripts.Units.Components;
using Assets.Scripts.Weapons.WeaponFactories;
using UnityEngine;

namespace Assets.Scripts.Units.Player
{
    public class PlayerShipController : UnitControllerBase
    {
        [SerializeField]
        private WeaponFactoryBase _weaponFactory;

        [SerializeField]
        private GameObject _prefabExplosionEffect;

        public override void InitInternal(UnitBase unit, UnitContext unitContext)
        {
            _components.Add(new EffectAfterDeathComponent(unit, unitContext, _prefabExplosionEffect));

            WeaponComponent newWeaponComponent = new WeaponComponent(unit, unitContext, _weaponFactory.Create());
            _components.Add(newWeaponComponent);

            _components.Add(new PlayerInputComponent(unit, unitContext, newWeaponComponent));
            _components.Add(new RotateModelComponent(unit, unitContext));

            // Applyers
            _components.Add(new DamageApplyerComponent(unit, unitContext));
            _components.Add(new MovementApplyerComponent(unit, unitContext));
            _components.Add(new TeamApplyerComponent(unit, unitContext));
            _components.Add(new DieApplyerComponent(unit, unitContext));
            _components.Add(new ReviveApplyerComponent(unit, unitContext));
            _components.Add(new DestroyApplyerComponent(unit, unitContext));
            _components.Add(new ResetApplyerComponent(unit, unitContext));
        }
    }
}