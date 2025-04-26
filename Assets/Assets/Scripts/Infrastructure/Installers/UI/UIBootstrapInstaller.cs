using Extensions;
using Infrastructure.UI;
using UI;

namespace Infrastructure
{
    public class UIBootstrapInstaller : UIInstaller
    {
        protected override void InstallWindows()
        {
            Container.BindPresenterWithView<UILoadingPresenter, UILoadingView>();
        }
    }
}