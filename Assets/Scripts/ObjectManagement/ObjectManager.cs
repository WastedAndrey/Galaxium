using System;
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    public class ObjectManager : MonoBehaviour
    {
        private static ObjectManager _instanse;
        public static ObjectManager Instanse { get => _instanse; }

        private void Awake()
        {
            if (_instanse == null)
            {
                _instanse = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject); 
        }

        public T InstantiatePrefab<T>(T prefab) where T : UnityEngine.Object
        {
            T newObject = Instantiate(prefab);
            return newObject;
        }
        public T InstantiatePrefab<T>(T prefab, Vector3 position) where T : MonoBehaviour
        {
            T newObject = Instantiate(prefab, position, prefab.transform.rotation);
            return newObject;
        }
        public T InstantiatePrefab<T>(T prefab, Vector3 position, Quaternion rotation) where T : MonoBehaviour
        {
            T newObject = Instantiate(prefab, position, rotation);
            return newObject;
        }
        public T InstantiatePrefab<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : MonoBehaviour
        {
            T newObject = Instantiate(prefab, position, rotation, parent);
            return newObject;
        }
        public GameObject InstantiatePrefab(GameObject prefab)
        {
            GameObject newObject = Instantiate(prefab);
            return newObject;
        }
        public GameObject InstantiatePrefab(GameObject prefab, Vector3 position)
        {
            GameObject newObject = Instantiate(prefab, position, prefab.transform.rotation);
            return newObject;
        }
        public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject newObject = Instantiate(prefab, position, rotation);
            return newObject;
        }

        public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            GameObject newObject = Instantiate(prefab, position, rotation, parent);
            return newObject;
        }

        public T InstantiateFromAsset<T>(string assetId, Action<T> afterLoad) where T : MonoBehaviour
        {
            T result = null;
            //
            //afterLoad
            return result;
        }

        public void DestroyObject(GameObject someObject)
        {
            ObjectPoolComponent tagComponent = someObject.GetComponent<ObjectPoolComponent>();
            if (tagComponent != null)
                ObjectPoolManager.Instance.StoreObject(tagComponent);
            else
            {
                Destroy(someObject);
            }
        }
    }
}
