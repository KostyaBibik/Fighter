using Core;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEntryPoint();
        }

        private void BindEntryPoint()
        {
            Container.BindInterfacesAndSelfTo<BootstrapEntryPoint>().AsSingle().NonLazy();
        }
    }
}