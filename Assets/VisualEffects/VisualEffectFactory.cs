
using Assets.Scripts.ObjectManagement;
using UnityEngine;
using Zenject;

namespace Assets.VisualEffects
{
    public class VisualEffectFactory : IFactory<VisualEffectBase, Vector3, Quaternion, Transform, float, VisualEffectBase>
    {
        private ObjectManager _objectManager;

        [Inject]
        public VisualEffectFactory(ObjectManager objectManager)
        {
            _objectManager = objectManager;
        }

        public VisualEffectBase Create(VisualEffectBase prefab, Vector3 position, Quaternion rotation, Transform parent, float lifetime = 0)
        {
            var newEffect = _objectManager.InstantiatePrefab(prefab, position, rotation, parent);
            newEffect.Init(lifetime);
            return newEffect;
        }
    }
}