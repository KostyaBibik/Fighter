using Core;
using DataBase;
using DataBase;
using UnityEngine;

namespace Infrastructure
{
    public class Game2DInstaller : BaseGameInstaller
    {
        [SerializeField] private Prefabs2DConfig _prefabsConfig;

        protected override void InstallConfigs()
        {
            Container.Bind<IPrefabsConfig>().FromInstance(_prefabsConfig).AsSingle();
        }

        protected override void InstallPlayerMovement()
        {
            Container.BindInterfacesAndSelfTo<PlayerMovement2D>().AsSingle();
        }
    }
}