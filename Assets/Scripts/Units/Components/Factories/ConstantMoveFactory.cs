
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Components.Factories
{
    public class ConstantMoveFactory : ComponentFactoryWithSettingsBase<Vector2, ConstantMoveComponent>
    {
        
        public ConstantMoveFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}