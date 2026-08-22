using Utilities.AssetLoading;
using UI;
using Zenject;

namespace Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        private AssetsProvider _assetsProvider;

        [Inject]
        public void Construct(AssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public override void InstallBindings()
        {
            BindUI();
        }

        private void BindUI()
        {
            Container.Bind<MainMenuUIModel>().AsSingle();
            Container.BindFactory<MainMenuUIView, MainMenuUIViewFactory>().FromComponentInNewPrefab(_assetsProvider.MainMenuUIObject);
            Container.Bind<MainMenuUIPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuUIPresenterInitializer>().AsSingle();
            Container.BindExecutionOrder<MainMenuUIPresenterInitializer>(-1);
        }
    }
}