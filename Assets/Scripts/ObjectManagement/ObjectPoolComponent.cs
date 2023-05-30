
using System;
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    public class ObjectPoolComponent : MonoBehaviour, IObjectPoolComponent
    {
        [SerializeField]
        private ObjectPoolTag _poolTag;

        public ObjectPoolTag PoolTag => _poolTag;
        public Action Reseted { get; set; }

        public void ResetObject()
        {
            Reseted?.Invoke();
        }

        private void OnDestroy()
        {
            Reseted = null;
        }
    }
}