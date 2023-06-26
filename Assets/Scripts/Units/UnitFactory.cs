
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units
{
    public class UnitFactory : IFactory<GameObject, GameObject>
    {
        private DiContainer _container;
        private readonly GameObject _prefab;

        public UnitFactory(GameObject prefab)
        {
            _prefab = prefab;
        }

        public GameObject Create(GameObject prefab)
        {
            return _container.InstantiatePrefab(_prefab);
        }
    }
}