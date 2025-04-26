using Core;
using DataBase;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ScenesConfig _sceneConfig;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            InstallConfigs();
            InstallServices();
        }

        private void InstallConfigs()
        {
            Container
                .Bind<ScenesConfig>()
                .FromScriptableObject(_sceneConfig)
                .AsSingle();  
            
            Container
                .Bind<PlayerConfig>()
                .FromScriptableObject(_playerConfig)
                .AsSingle();
            
            Container
                .Bind<EnemyConfig>()
                .FromScriptableObject(_enemyConfig)
                .AsSingle();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputSystemProvider>().AsSingle().NonLazy();
        }
    }
}