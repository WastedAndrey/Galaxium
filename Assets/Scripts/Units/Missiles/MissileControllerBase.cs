using Assets.Scripts.Units.Components.CommandApplyers.Factories;
using Assets.Scripts.Units.Components.Factories;
using Assets.Scripts.Units.Missiles.Components.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Missiles
{
    public class MissileControllerBase : UnitControllerBase
    {
        [SerializeField]
        private GameObject _prefabExplosionEffect;
        [SerializeField]
        private float _lifetimeMax = 3;

        [Inject]
        private MissileCollisionFactory _missileCollisionFactory;
        [Inject]
        private LimitedTimeFactory _limitedTimeFactory;
        [Inject]
        private ConstantMoveFactory _constantMoveFactory;
        [Inject]
        private EffectAfterDeathFactory _effectAfterDeathFactory;
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
            _components.Add(_missileCollisionFactory.Create(unit, unitContext));
            _components.Add(_limitedTimeFactory.Create(unit, unitContext, _lifetimeMax));
            _components.Add(_constantMoveFactory.Create(unit, unitContext, Vector2.up));
            _components.Add(_effectAfterDeathFactory.Create(unit, unitContext, _prefabExplosionEffect));



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