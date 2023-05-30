
using Assets.Scripts.ObjectManagement;

namespace Assets.Scripts.Units.Components
{
    public class ResetApplyerComponent : UnitComponentBase
    {
        private ObjectPoolComponent _poolComponent;

        public ResetApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
            _poolComponent = unit.GetComponent<ObjectPoolComponent>();
            _poolComponent.Reseted += ResetObject;
        }
        public override void OnDestroy()
        {
            _poolComponent.Reseted -= ResetObject;
        }
        private void ResetObject()
        {
            _unit.ResetUnit();
        }
    }
}