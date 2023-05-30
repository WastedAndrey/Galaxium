
using Assets.Scripts.Units.Components;
using UnityEngine;

namespace Assets.Scripts.Units.Missiles
{
    public class MissileCollisionComponent : UnitComponentBase
    {
        public MissileCollisionComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }

        public override void OnEnable()
        {
            _context.MonoBehaviourEvents.OnTriggerEnter += OnTriggerEnter;
        }
        public override void OnDisable()
        {
            _context.MonoBehaviourEvents.OnTriggerEnter -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            UnitLink unitLink = other.GetComponent<UnitLink>();
            if (unitLink != null && unitLink.Unit != null && _unit.Team != unitLink.Unit.Team)
            {
                unitLink.Unit.ReceiveDamage(_context.AttackDamage);
                _unit.Die();
            }
          
        }
    }
}