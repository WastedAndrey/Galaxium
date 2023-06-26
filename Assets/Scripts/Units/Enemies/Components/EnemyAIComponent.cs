
using Assets.Scripts.Units.Components;

namespace Assets.Scripts.Units.Enemies.Components
{
    public class EnemyAISettings
    {
        private MovementPattern _movementPattern;
        private WeaponComponent _weaponComponent;

        public MovementPattern MovementPattern { get => _movementPattern; set => _movementPattern = value; }
        public WeaponComponent WeaponComponent { get => _weaponComponent; set => _weaponComponent = value; }

        public EnemyAISettings(MovementPattern movementPattern, WeaponComponent weaponComponent)
        {
            _movementPattern = movementPattern;
            _weaponComponent = weaponComponent;
        }
    }

    public class EnemyAIComponent : UnitComponentBase
    {
        private EnemyAISettings _enemySettings;

        private MovementPattern MovementPattern => _enemySettings.MovementPattern;
        private WeaponComponent WeaponComponent => _enemySettings.WeaponComponent;

        public EnemyAIComponent(UnitBase unit, UnitContext unitContext, EnemyAISettings enemySettings) : base(unit, unitContext)
        {
            _enemySettings = enemySettings;
        }

        public override void Update(float deltaTime)
        {
            if (_context.IsAlive)
            {
                if (MovementPattern.Finished == false)
                {
                    MovementPattern.Update(deltaTime);
                    _unit.Move(MovementPattern.CurrentMovementVector);
                }
                else
                    MovementPattern.Reset();

                WeaponComponent.Shoot();
            }
                
        }
    }
}