
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Factories
{
    public class MonoBehaviourFactory : IFactory<GameObject, GameObject>
    {
        private DiContainer _container;

        public MonoBehaviourFactory()
        {
        }

        public GameObject Create(GameObject prefab)
        {
            return _container.InstantiatePrefab(prefab);
        }
    }
}