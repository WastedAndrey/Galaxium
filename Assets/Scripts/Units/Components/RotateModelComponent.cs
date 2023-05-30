
using Assets.Scripts.General;
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class RotateModelComponent : UnitComponentBase
    {
        private float _angleMax = 45;
        private float _rotationSpeedMax = 30;
        private float _rotationAcceleration = 60;
        private float _stabilizeSpeed = 6f;

        private float _rotationSpeedCurrent;
        

        public RotateModelComponent(UnitBase unit, UnitContext unitContext) : base(unit, unitContext)
        {
        }

        public override void OnEnable()
        {
            _unit.Moved += OnMove;
        }

        public override void OnDisable()
        {
            _unit.Moved -= OnMove;
        }

        public override void Update(float deltaTime)
        {
            Vector3 currentAngle = _context.Model.transform.rotation.eulerAngles;
            currentAngle.y = GameMaths.NormalizeDegreeToAbs180(currentAngle.y);
            bool angleUpdated = false;

            if (_rotationSpeedCurrent != 0)
            {
                currentAngle.y += _rotationSpeedCurrent;
                _rotationSpeedCurrent = Mathf.Lerp(_rotationSpeedCurrent, 0, _stabilizeSpeed * 4 * deltaTime);
                angleUpdated = true;
            }

            if (currentAngle.y != 0)
            {
                currentAngle.y = Mathf.Lerp(currentAngle.y, 0, _stabilizeSpeed * deltaTime);
                angleUpdated = true;
            }

            if (angleUpdated)
            {
                currentAngle.y = Mathf.Clamp(currentAngle.y, -_angleMax, _angleMax);
                _context.Model.transform.rotation = Quaternion.Euler(currentAngle);
            }
        }

        private void OnMove(UnitBase unit, Vector2 movementVector)
        {
            if (movementVector != Vector2.zero)
            {
                movementVector = _unit.Rotation * movementVector;
                _rotationSpeedCurrent += _rotationAcceleration * -movementVector.x;
                _rotationSpeedCurrent = Mathf.Clamp(_rotationSpeedCurrent, -_rotationSpeedMax, _rotationSpeedMax);
            }
          
        }
    }
}