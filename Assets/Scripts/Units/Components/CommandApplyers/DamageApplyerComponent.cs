
using Assets.Scripts.Units.CommandsData;
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class DamageApplyerComponent : UnitComponentBase
    {
        public DamageApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        { 
        }
        public override void OnEnable()
        {
            _context.UnitCommands.ReceiveDamage += ReceiveDamage;
            _context.UnitCommands.RestoreAllHealth += RestoreAllHealth;
            _context.UnitCommands.RestoreHealth += RestoreHealth;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.ReceiveDamage -= ReceiveDamage;
            _context.UnitCommands.RestoreAllHealth -= RestoreAllHealth;
            _context.UnitCommands.RestoreHealth -= RestoreHealth;
        }
        public void ReceiveDamage(DamageData damage)
        {
            if (_context.IsAlive == false)
                return;

            damage.FinalValue = Mathf.Clamp(damage.FinalValue, 0, _context.Health);
            _context.Health -= damage.FinalValue;

            if (_context.Health <= 0)
                _unit.Die();
        }
        public void RestoreAllHealth(DamageData restoreData)
        {
            if (_context.IsAlive == false)
                return;

            restoreData.FinalValue = Mathf.Clamp(restoreData.FinalValue, 0, _context.HealthMax - _context.Health);
            _context.Health += restoreData.FinalValue;
        }
        public void RestoreHealth(DamageData restoreData)
        {
            if (_context.IsAlive == false)
                return;

            restoreData.FinalValue = Mathf.Clamp(restoreData.FinalValue, 0, _context.HealthMax - _context.Health);
            _context.Health += restoreData.FinalValue;
        }
    }
}