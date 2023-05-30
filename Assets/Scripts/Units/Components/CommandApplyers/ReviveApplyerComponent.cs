
using Assets.Scripts.Units.CommandsData;

namespace Assets.Scripts.Units.Components
{
    public class ReviveApplyerComponent : UnitComponentBase
    {
        public ReviveApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }
        public override void OnEnable()
        {
            _context.UnitCommands.Revive += Revive;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.Revive -= Revive;
        }

        public void Revive(BoolData reviveData)
        {
            if (_context.IsAlive == false && reviveData.FinalValue)
            {
                _context.StatsCurrent.CopyFrom(_context.StatsDefault);
                _context.IsAlive = true;
            }
        }
    }
}