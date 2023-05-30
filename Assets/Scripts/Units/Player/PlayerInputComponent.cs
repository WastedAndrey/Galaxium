
using Assets.Scripts.Units.Components;
using UnityEngine;

namespace Assets.Scripts.Units.Player
{
    public class PlayerInputComponent : UnitComponentBase
    {
        private WeaponComponent _weaponComponent;

        public PlayerInputComponent(UnitBase unit, UnitContext unitContext, WeaponComponent weaponComponent) : base(unit, unitContext)
        {
            _weaponComponent = weaponComponent;
        }

        public override void Update(float deltaTime)
        {
            if (_context.IsAlive)
            {
                Vector2 movementVector = new Vector2();
                movementVector.x = Input.GetAxis("Horizontal");
                movementVector.y = Input.GetAxis("Vertical");
                movementVector.Normalize();
                movementVector *= _context.MovementSpeed;

                if (movementVector != Vector2.zero)
                    _unit.Move(movementVector);

                if (Input.GetKey(KeyCode.Space))
                    _weaponComponent.Shoot();
            }
        }
    }
}