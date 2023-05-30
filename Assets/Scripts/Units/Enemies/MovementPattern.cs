
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Enemies
{
    [System.Serializable]
    public class MovementPattern
    {
        [SerializeField]
        private List<MovementOperation> _movementOperations = new List<MovementOperation>();

        private int _currentIndex = 0;
        public bool Finished { get; private set; } = false;
        public Vector2 CurrentMovementVector { get; private set; }

        public void Update(float deltaTime)
        {
            CurrentMovementVector = Vector2.zero;

            bool done = false;
            while (done == false && Finished == false) 
            {
                _movementOperations[_currentIndex].Update(deltaTime);
                CurrentMovementVector += _movementOperations[_currentIndex].CurrentMovementVector;


                if (_movementOperations[_currentIndex].IsFinished == false)
                    done = true;
                else
                {
                    deltaTime = _movementOperations[_currentIndex].TimeLeftAfterFinish;
                    IncreaseIndex();
                }
            }
        }

        private void IncreaseIndex()
        {
            _currentIndex++;
            if (_currentIndex < _movementOperations.Count)
            {
                _movementOperations[_currentIndex].Start();
            }
            else
            {
                Finish();
            }
           
        }

        private void Finish()
        {
            Reset();
            Finished = true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }

    [System.Serializable]
    public class MovementOperation
    {
        [SerializeField]
        private float _time;
        [SerializeField]
        private Vector2 _movementVector;

        private float _timeCurrent;

        public bool IsFinished { get; private set; }
        public Vector2 CurrentMovementVector { get; private set; }
        public float TimeLeftAfterFinish { get; private set; }  // After update and reaching the target point some time can be still left if target point is close enough

        public void Start()
        {
            Reset();
        }

        public void Update(float deltaTime)
        {
            _timeCurrent += deltaTime;

            if (_timeCurrent >= _time)
            {
                IsFinished = true;
                TimeLeftAfterFinish = _time - _timeCurrent;
                deltaTime = deltaTime - TimeLeftAfterFinish;
            }

            float lerpValue = deltaTime / _time;
            lerpValue = Mathf.Clamp(lerpValue, 0f, 1f);
            CurrentMovementVector = _movementVector * lerpValue;
        }

        public void Reset()
        {
            _timeCurrent = 0;
            IsFinished = false;
            TimeLeftAfterFinish = 0;
        }
    }
}