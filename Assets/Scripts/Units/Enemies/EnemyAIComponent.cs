
using Assets.Scripts.Units.Components;

namespace Assets.Scripts.Units.Enemies
{
    public class EnemyAIComponent : UnitComponentBase
    {
        private MovementPattern _movementPattern;
        private WeaponComponent _weaponComponent;

        public EnemyAIComponent(UnitBase unit, UnitContext unitContext, MovementPattern movementPattern, WeaponComponent weaponComponent) : base(unit, unitContext)
        {
            _movementPattern = movementPattern;
            _weaponComponent = weaponComponent;
        }

        public override void Update(float deltaTime)
        {
            if (_context.IsAlive)
            {
                if (_movementPattern.Finished == false)
                {
                    _movementPattern.Update(deltaTime);
                    _unit.Move(_movementPattern.CurrentMovementVector);
                }
                else
                    _movementPattern.Reset();

                _weaponComponent.Shoot();
            }
                
        }
    }
}