using Core;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public abstract class BaseGameInstaller : MonoInstaller
    {
        [SerializeField] protected SceneHandler SceneHandler;
        [SerializeField] protected PlayerView PlayerView;

        public override void InstallBindings()
        {
            InstallConfigs();
            InstallSceneHandler();
            InstallProviders();
            InstallFactories();
            InstallPlayerComponents();
            InstallPlayerAttack();
            InstallServices();
        }

        protected abstract void InstallConfigs();

        protected virtual void InstallSceneHandler()
        {
            Container.Bind<SceneHandler>().FromInstance(SceneHandler).AsSingle();
        }

        protected virtual void InstallProviders()
        {
            Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();
        }

        protected virtual void InstallFactories()
        {
            Container.Bind<EnemyRegistry>().AsSingle();
            Container.BindInterfacesTo<EnemyFactory>().AsSingle();
            Container.BindInterfacesTo<PlayerFactory>().AsSingle();
        }

        protected virtual void InstallPlayerComponents()
        {
            Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(PlayerView).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInitializer>().AsSingle();
            InstallPlayerMovement();
        }

        protected abstract void InstallPlayerMovement();

        protected virtual void InstallPlayerAttack()
        {
            Container.BindInterfacesAndSelfTo<PlayerAttackSystem>().AsSingle();
        }

        protected virtual void InstallServices()
        {
            Container.BindInterfacesTo<EnemySpawner>().AsSingle().NonLazy();
        }
    }
}