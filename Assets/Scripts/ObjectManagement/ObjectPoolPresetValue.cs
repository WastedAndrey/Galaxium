
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    [System.Serializable]
    public class ObjectPoolPresetValue
    {
        [SerializeField]
        private ObjectPoolTag _tag = ObjectPoolTag.Default;
        [SerializeField]
        private uint _objectsLimit = 10;

        public ObjectPoolTag Tag => Tag;
        public uint ObjectsLimit => _objectsLimit;
    }
}