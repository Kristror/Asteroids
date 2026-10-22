using Store;
using UI;
using Utilities.AssetLoading;
using Zenject;

namespace Installers
{
    public class StoreInstaller : MonoInstaller
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
            Container.Bind<PurchaseController>().AsSingle();

            Container.BindFactory<StoreUIView, StoreUIViewFactory>().FromComponentInNewPrefab(_assetsProvider.StoreUIObject);
            Container.BindFactory<BuyButton, BuyItemButtonFactory>().FromComponentInNewPrefab(_assetsProvider.BuyButtonObject);

            Container.Bind<StoreUIModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<StoreUIPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<StoreUIPresenterInitializer>().AsSingle();
            Container.BindExecutionOrder<StoreUIPresenterInitializer>(-1);
        }
    }
}