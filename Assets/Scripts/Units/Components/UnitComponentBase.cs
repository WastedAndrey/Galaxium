
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public abstract class UnitComponentBase
    {
        [SerializeField]
        protected UnitBase _unit;
        [SerializeField]
        protected UnitContext _context;

        public UnitComponentBase(UnitBase unit, UnitContext unitContext)
        {
            _unit = unit;
            _context = unitContext;
        }

        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void OnDestroy() { }
        public virtual void Update(float deltaTime) { }
        public virtual void FixedUpdate(float deltaTime) { }
    }
}