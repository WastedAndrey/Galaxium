
using Assets.Scripts.Units.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units
{
    public abstract class UnitControllerBase : MonoBehaviour
    {
        protected UnitBase _unit;
        protected UnitContext _unitContext;

        protected List<UnitComponentBase> _components = new List<UnitComponentBase>();

        public void Init(UnitBase unit, UnitContext unitContext)
        {
            _unit = unit;
            _unitContext = unitContext;

            unitContext.MonoBehaviourEvents.Enabled += Enabled;
            unitContext.MonoBehaviourEvents.Disabled += Disabled;
            unitContext.MonoBehaviourEvents.Updated += Updated;
            unitContext.MonoBehaviourEvents.FixedUpdated += FixedUpdated;
            unitContext.MonoBehaviourEvents.Destroyed += Destroyed;

            InitInternal(unit, unitContext);
        }

        public abstract void InitInternal(UnitBase unit, UnitContext unitContext);

        protected void Enabled()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].OnEnable();
            }
        }

        protected void Disabled()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].OnDisable();
            }
        }

        protected void Updated(float deltaTime)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Update(deltaTime);
            }
        }

        protected void FixedUpdated(float deltaTime)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].FixedUpdate(deltaTime);
            }
        }


        protected void Destroyed()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].OnDestroy();
            }

            _unitContext.MonoBehaviourEvents.Enabled -= Enabled;
            _unitContext.MonoBehaviourEvents.Disabled -= Disabled;
            _unitContext.MonoBehaviourEvents.Updated -= Updated;
            _unitContext.MonoBehaviourEvents.Destroyed -= Destroyed;
        }
    }
}