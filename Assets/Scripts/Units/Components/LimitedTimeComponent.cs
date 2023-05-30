
namespace Assets.Scripts.Units.Components
{
    public class LimitedTimeComponent : UnitComponentBase
    {
        private float _lifetimeMax;
        private float _lifetime;

        public LimitedTimeComponent(UnitBase unit, UnitContext unitContext, float lifetimeMax) : base(unit, unitContext)
        {
            _lifetimeMax = lifetimeMax;
            _unit.Reseted += ResetTime;
        }

        public override void OnDestroy()
        {
            _unit.Reseted -= ResetTime;
        }

        public override void Update(float deltaTime)
        {
            _lifetime += deltaTime;
            if (_lifetime >= _lifetimeMax)
                _unit.Die();
        }

        private void ResetTime(UnitBase unit)
        {
            _lifetime = 0;
        }
    }
}