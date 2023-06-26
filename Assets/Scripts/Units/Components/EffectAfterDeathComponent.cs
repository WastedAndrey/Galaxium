
using Assets.Scripts.ObjectManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Components
{
    public class EffectAfterDeathComponent : UnitComponentBase
    {
        [Inject]
        private ObjectManager _objectManager;
        private GameObject _prefabEffect;

        public EffectAfterDeathComponent(UnitBase unit, UnitContext unitContext, GameObject prefab) : base(unit, unitContext)
        {
            _prefabEffect = prefab;
        }
        public override void OnEnable()
        {
            _unit.Died += OnUnitDied;
        }

        public override void OnDisable()
        {
            _unit.Died -= OnUnitDied;
        }

        private void OnUnitDied(UnitBase unit) => CreateEffect();

        private void CreateEffect()
        {
            if (_prefabEffect != null)
                _objectManager.InstantiatePrefab(_prefabEffect, _unit.Position);
        }
    }
}