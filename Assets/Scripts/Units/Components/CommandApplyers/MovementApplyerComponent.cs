
using Assets.Scripts.Units.CommandsData;
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class MovementApplyerComponent : UnitComponentBase
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _velocity;

        public MovementApplyerComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
            _rigidbody = unit.GetComponent<Rigidbody2D>();
        }
        public override void OnEnable()
        {
            _context.UnitCommands.Move += Move;
            _context.UnitCommands.Teleport += Teleport;
        }

        public override void OnDisable()
        {
            _context.UnitCommands.Move -= Move;
            _context.UnitCommands.Teleport -= Teleport;
        }

        public override void Update(float deltaTime)
        {
            _context.MovementVector += _velocity * deltaTime;
            _rigidbody.velocity = _velocity;
            _velocity = Vector2.zero;
        }

        private void Move(MovementData movementData)
        {
            _velocity += movementData.FinalValue;
        }

        private void Teleport(MovementData movementData)
        {
            _context.MovementVector += (movementData.FinalValue - _rigidbody.position);
            _rigidbody.MovePosition(movementData.FinalValue);
            
        }
    }
}