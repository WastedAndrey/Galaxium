
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
        public Action RemoveRequested { get; set; }
        public Action Removed { get; set; }
        public Action Destroyed { get; set; }
       
 
        public void ResetObject()
        {
            Reseted?.Invoke();
        }

        public void Remove()
        {
            RemoveRequested?.Invoke();
        }

        private void OnDestroy()
        {
            Reseted = null;
        }
    }
}