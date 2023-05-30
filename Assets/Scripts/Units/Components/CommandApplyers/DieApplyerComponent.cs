
using Assets.Scripts.Units.CommandsData;

namespace Assets.Scripts.Units.Components
{
    public class DieApplyerComponent : UnitComponentBase
    {
        public DieApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }
        public override void OnEnable()
        {
            _context.UnitCommands.Die += Die;
            _unit.Died += OnDied;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.Die -= Die;
            _unit.Died -= OnDied;
        }
        private void Die(BoolData deathData)
        {
            if (_context.IsAlive == true && deathData.FinalValue)
            {
                _context.IsAlive = deathData.FinalValue;
                
            }
        }

        private void OnDied(UnitBase unit)
        {
            _unit.DestroyObject();
        }
    }
}