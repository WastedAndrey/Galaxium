
using Assets.Scripts.ObjectManagement;
using UnityEngine;

namespace Assets.Scripts.Units.Components
{
    public class EffectAfterDeathComponent : UnitComponentBase
    {
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
                ObjectManager.Instanse.InstantiatePrefab(_prefabEffect, _unit.Position);
        }
    }
}