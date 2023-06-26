
using Assets.Scripts.Units.Components;
using Assets.Scripts.Units.Components.CommandApplyers.Factories;
using Assets.Scripts.Units.Components.Factories;
using Assets.Scripts.Units.Enemies.Components;
using Assets.Scripts.Units.Enemies.Components.Factories;
using Assets.Scripts.Weapons.WeaponFactories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Enemies
{
    public class EnemyShipController : UnitControllerBase
    {
        [SerializeField]
        private WeaponFactoryBase _weaponFactory;
        [SerializeField]
        private MovementPattern _movementPattern;

        [SerializeField]
        private GameObject _prefabExplosionEffect;

        [Inject]
        private EffectAfterDeathFactory _effectAfterDeathFactory;
        [Inject]
        private WeaponFactory _weaponComponentFactory;
        [Inject]
        private EnemyAIFactory _enemyAIFactory;
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

            var newWeaponComponent = _weaponComponentFactory.Create(unit, unitContext, _weaponFactory.Create());
            _components.Add(newWeaponComponent);

            var enemyAISettings = new EnemyAISettings(_movementPattern, newWeaponComponent);
            _components.Add(_enemyAIFactory.Create(unit, unitContext, enemyAISettings));

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