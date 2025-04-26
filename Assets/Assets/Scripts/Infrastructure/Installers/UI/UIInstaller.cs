using Zenject;

namespace Infrastructure.UI
{
    public abstract class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallWindows();
        }

        protected virtual void InstallWindows()
        {
        }
    }
}