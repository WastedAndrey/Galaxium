
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class ConstantMoveComponent : UnitComponentBase
    {
        private Vector2 _direction;

        public ConstantMoveComponent(UnitBase unit, UnitContext unitContext, Vector2 direction) : base(unit, unitContext)
        {
            _direction = direction;
        }

        public override void Update(float deltaTime)
        {
            _unit.Move(_unit.Rotation * _direction * _context.MovementSpeed);
        }
    }
}