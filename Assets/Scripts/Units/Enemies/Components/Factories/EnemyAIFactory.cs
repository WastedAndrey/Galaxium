
using Assets.Scripts.Units.Components.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Units.Enemies.Components.Factories
{
    public class EnemyAIFactory : ComponentFactoryWithSettingsBase<EnemyAISettings, EnemyAIComponent>
    {
        public EnemyAIFactory(DiContainer diContainer) : base(diContainer)
        {
        }
    }
}