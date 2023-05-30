using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private class ObjectPoolData
        {
            public Stack<ObjectPoolComponent> Objects { get; set; } = new Stack<ObjectPoolComponent>();
            public uint ObjectsLimit = 10;
            public bool CanAddObject { get => Objects.Count < ObjectsLimit; }
            public bool CanGetObject { get => Objects.Count > 0; }
        }

        [SerializeField]
        private ObjectPoolPreset _preset;
        [SerializeField]
        private Transform _storedObjectsParent;

        private Dictionary<ObjectPoolTag, ObjectPoolData> _pool;

        private static ObjectPoolManager _instance;
        public static ObjectPoolManager Instance { get => _instance; }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }

            _pool = new Dictionary<ObjectPoolTag, ObjectPoolData>();
            InitFromPreset();
        }

        private void InitFromPreset()
        {
            if (_preset == null)
                return;

            var values = _preset.GetValues();
            for (int i = 0; i < values.Length; i++)
            {
                TryAddNewTag(values[i].Tag);
                SetTagItemsLimit(values[i].Tag, values[i].ObjectsLimit);
            }
        }

        public bool StoreObject(ObjectPoolComponent objectForPool, bool destroyIfPoolFull = true)
        {
            ObjectPoolTag tag = objectForPool.PoolTag;

            TryAddNewTag(objectForPool.PoolTag);

            if (_pool[tag].CanAddObject)
            {
                objectForPool.transform.SetParent(_storedObjectsParent);
                objectForPool.gameObject.SetActive(false);

                _pool[tag].Objects.Push(objectForPool);
                return true;
            }
            else
            {
                if (destroyIfPoolFull)
                    Destroy(objectForPool.gameObject);

                return false;
            }   
        }

        public ObjectPoolComponent GetObject(ObjectPoolTag tag)
        {
            if (_pool.ContainsKey(tag) == false || _pool[tag].CanGetObject == false)
                return null;
            else
            {
                ObjectPoolComponent someObject = _pool[tag].Objects.Pop();
                someObject.Reseted?.Invoke();
                return someObject;
            }
               
        }

        public void SetTagItemsLimit(ObjectPoolTag tag, uint limit)
        {
            TryAddNewTag(tag);
            _pool[tag].ObjectsLimit = limit;

        }

        public void Clear(bool destroyStoredItems)
        {
            if (destroyStoredItems)
            {
                var objectsList = _pool.Values.ToList();
                for (int i = 0; i < objectsList.Count; i++)
                {
                    while (objectsList[i].Objects.Count > 0)
                    {
                        var someObject = objectsList[i].Objects.Pop();
                        Destroy(someObject);
                    }
                }
            }

            _pool.Clear();
        }

        private void TryAddNewTag(ObjectPoolTag tag)
        {
            if (_pool.ContainsKey(tag) == false)
                _pool.Add(tag, new ObjectPoolData());
        }
    }
}
