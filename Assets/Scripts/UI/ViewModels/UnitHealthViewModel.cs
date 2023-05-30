
using Assets.Scripts.General;
using Assets.Scripts.UI.ViewModels.Interfaces;
using Assets.Scripts.Units;

namespace Assets.Scripts.UI.ViewModels
{
    public class UnitHealthViewModel : IPropertyViewModel<float>
    {
        private ReactiveProperty<float> _value = new ReactiveProperty<float>();
        public IReactivePropertyReadOnly<float> Property => _value;

        private UnitBase _unit;

        public UnitHealthViewModel(UnitBase unit)
        {
            _unit = unit;
            _unit.StatsDefault.Health.Changed += HealthChanged;
            _unit.StatsCurrent.Health.Changed += HealthChanged;
            _unit.Destroyed += OnUnitDestroyed;
            UpdateValue();
        }

        private void HealthChanged(float health) => UpdateValue();
        private void UpdateValue()
        {
            _value.Value = _unit.StatsCurrent.Health.Value / _unit.StatsDefault.Health.Value;
        }

        public void OnUnitDestroyed(UnitBase unit) { Dispose(); }
        public void Dispose()
        {
            _unit.StatsDefault.Health.Changed -= HealthChanged;
            _unit.StatsCurrent.Health.Changed -= HealthChanged;
            _unit.Destroyed -= OnUnitDestroyed;
        }
    }
}