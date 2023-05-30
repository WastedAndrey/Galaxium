
using Assets.Scripts.Units.CommandsData;

namespace Assets.Scripts.Units.Components
{
    public class TeamApplyerComponent : UnitComponentBase
    {
        public TeamApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }
        public override void OnEnable()
        {
            _context.UnitCommands.SetTeam += SetTeam;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.SetTeam -= SetTeam;
        }

        private void SetTeam(UnitTeamData teamData)
        {
            _context.StatusesDefault.Team.Value = teamData.FinalValue;
            _context.StatusesCurrent.Team.Value = teamData.FinalValue;
        }
    }
}