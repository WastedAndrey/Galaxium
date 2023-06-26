
using Assets.Scripts.ObjectManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Missiles
{
    public class MissileFactory : IFactory<UnitBase, Vector3, Quaternion, Transform, UnitTeam, UnitBase>
    {
        private ObjectManager _objectManager;

        [Inject]
        public MissileFactory(ObjectManager objectManager)
        {
            _objectManager = objectManager;
        }

        public UnitBase Create(UnitBase prefab, Vector3 position, Quaternion rotation, Transform parent, UnitTeam team)
        {
            var newMissile = _objectManager.InstantiatePrefab(prefab, position, rotation, parent);
            newMissile.SetUnitTeam(team);
            return newMissile;
        } 
    }
}