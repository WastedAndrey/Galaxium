
using Assets.Scripts.Units;
using Assets.Scripts.Units.Components;
using Assets.Scripts.Units.Components.CommandApplyers.Factories;
using Assets.Scripts.Units.Components.Factories;
using Assets.Scripts.Units.Enemies.Components.Factories;
using Assets.Scripts.Units.Missiles.Components.Factories;
using Assets.Scripts.Units.Player.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject.Installers
{
    public class UnitFactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //applyers factories
            Container.Bind<DamageApplyerFactory>().AsSingle();
            Container.Bind<DestroyApplyerFactory>().AsSingle();
            Container.Bind<DieApplyerFactory>().AsSingle();
            Container.Bind<MovementApplyerFactory>().AsSingle();
            Container.Bind<ResetApplyerFactory>().AsSingle();
            Container.Bind<ReviveApplyerFactory>().AsSingle();
            Container.Bind<TeamApplyerFactory>().AsSingle();
            //components factories
            Container.Bind<ConstantMoveFactory>().AsSingle();
            Container.Bind<EffectAfterDeathFactory>().AsSingle();
            Container.Bind<LimitedTimeFactory>().AsSingle();
            Container.Bind<RotateModelFactory>().AsSingle();
            Container.Bind<WeaponFactory>().AsSingle();
            // additional components factories
            Container.Bind<EnemyAIFactory>().AsSingle();
            Container.Bind<MissileCollisionFactory>().AsSingle();
            Container.Bind<PlayerInputFactory>().AsSingle();
        }
    }
}