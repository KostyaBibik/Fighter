using Core;
using DataBase;
using DataBase;
using UnityEngine;

namespace Infrastructure
{
    public class Game3DInstaller : BaseGameInstaller
    {
        [SerializeField] private Prefabs3DConfig _prefabsConfig;

        protected override void InstallConfigs()
        {
            Container.Bind<IPrefabsConfig>().FromInstance(_prefabsConfig).AsSingle();
        }

        protected override void InstallPlayerMovement()
        {
            Container.BindInterfacesAndSelfTo<PlayerMovement3D>().AsSingle();
        }
    }
}