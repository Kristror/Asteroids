using AssetLoading;
using UI;
using Zenject;

namespace Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [Inject] private AssetsProvider _assetsProvider;

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
        }
    }
}