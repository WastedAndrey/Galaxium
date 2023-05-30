
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    [CreateAssetMenu(fileName = "ObjectPoolPreset", menuName = "Game/ObjectPoolPreset")]
    public class ObjectPoolPreset : ScriptableObject
    {
        [SerializeField] 
        private List<ObjectPoolPresetValue> _values = new List<ObjectPoolPresetValue>();

        public ObjectPoolPresetValue[] GetValues()
        {
            return _values.ToArray();
        }
    }
}