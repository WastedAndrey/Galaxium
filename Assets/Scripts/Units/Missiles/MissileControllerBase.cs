
using Assets.Scripts.Units.Components;
using UnityEngine;

namespace Assets.Scripts.Units.Missiles
{
    public class MissileControllerBase : UnitControllerBase
    {
        [SerializeField]
        private GameObject _prefabExplosionEffect;
        [SerializeField]
        private float _lifetimeMax = 3;

        public override void InitInternal(UnitBase unit, UnitContext unitContext)
        {
            _components.Add(new MissileCollisionComponent(unit, unitContext));
            _components.Add(new LimitedTimeComponent(unit, unitContext, _lifetimeMax));
            _components.Add(new ConstantMoveComponent(unit, unitContext, Vector2.up));
            _components.Add(new EffectAfterDeathComponent(unit, unitContext, _prefabExplosionEffect));
            
            

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