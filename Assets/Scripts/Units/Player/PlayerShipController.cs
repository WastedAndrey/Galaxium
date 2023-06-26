
using Assets.Scripts.Units.Components;
using Assets.Scripts.Units.Components.CommandApplyers.Factories;
using Assets.Scripts.Units.Components.Factories;
using Assets.Scripts.Units.Enemies.Components.Factories;
using Assets.Scripts.Units.Player.Factories;
using Assets.Scripts.Weapons.WeaponFactories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Player
{
    public class PlayerShipController : UnitControllerBase
    {
        [SerializeField]
        private WeaponFactoryBase _weaponFactory;

        [SerializeField]
        private GameObject _prefabExplosionEffect;

        [Inject]
        private EffectAfterDeathFactory _effectAfterDeathFactory;
        [Inject]
        private WeaponFactory _weaponComponentFactory;
        [Inject]
        private PlayerInputFactory _playerInputFactory;
        [Inject]
        private RotateModelFactory _rotateModelFactory;
        [Inject]
        private DamageApplyerFactory _damageApplyerFactory;
        [Inject]
        private MovementApplyerFactory _movementApplyerFactory;
        [Inject]
        private TeamApplyerFactory _teamApplyerFactory;
        [Inject]
        private DieApplyerFactory _dieApplyerFactory;
        [Inject]
        private ReviveApplyerFactory _reviveApplyerFactory;
        [Inject]
        private DestroyApplyerFactory _destroyApplyerFactory;
        [Inject]
        private ResetApplyerFactory _resetApplyerFactory;

        public override void InitInternal(UnitBase unit, UnitContext unitContext)
        {
            _components.Add(_effectAfterDeathFactory.Create(unit, unitContext, _prefabExplosionEffect));

            WeaponComponent newWeaponComponent = _weaponComponentFactory.Create(unit, unitContext, _weaponFactory.Create());
            _components.Add(newWeaponComponent);

            _components.Add(_playerInputFactory.Create(unit, unitContext, newWeaponComponent));
            _components.Add(_rotateModelFactory.Create(unit, unitContext));

            // Applyers
            _components.Add(_damageApplyerFactory.Create(unit, unitContext));
            _components.Add(_movementApplyerFactory.Create(unit, unitContext));
            _components.Add(_teamApplyerFactory.Create(unit, unitContext));
            _components.Add(_dieApplyerFactory.Create(unit, unitContext));
            _components.Add(_reviveApplyerFactory.Create(unit, unitContext));
            _components.Add(_destroyApplyerFactory.Create(unit, unitContext));
            _components.Add(_resetApplyerFactory.Create(unit, unitContext));
        }
    }
}