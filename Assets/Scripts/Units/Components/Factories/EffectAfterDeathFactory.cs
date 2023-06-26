
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public class EffectAfterDeathFactory : ComponentFactoryWithSettingsBase<GameObject, EffectAfterDeathComponent>
    {
        public EffectAfterDeathFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}