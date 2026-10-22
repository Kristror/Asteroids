using Ads;
using Configs;
using PlayerAnalytics;
using Store;
using Utilities;
using Utilities.AssetLoading;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoaders();
            BindUtilities();
            BindAnalytics();
            BindConfigs();
            BindShop();
            BindAds();
        }

        private void BindLoaders()
        {
            Container.Bind<IAssetLoader>().To<LocalAddressablesLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<AssetsProvider>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();

            Container.Bind<LoadingController>().AsSingle();
        }

        private void BindUtilities()
        {
            Container.BindInterfacesAndSelfTo<FirebaseAppProvider>().AsSingle();
            Container.BindExecutionOrder<FirebaseAppProvider>(2);
        }

        private void BindAnalytics()
        {
            Container.BindInterfacesAndSelfTo<FirebaseAnalyticsService>().AsSingle();
        }

        private void BindConfigs()
        {
            Container.BindInterfacesAndSelfTo<FirebaseRemoteConfigsProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConfigsController>().AsSingle();
        }

        private void BindShop()
        {
            Container.BindInterfacesAndSelfTo<UnityInAppPurchase>().AsSingle();
        }

        private void BindAds()
        {
            Container.BindInterfacesAndSelfTo<UnityLevelPlayAds>().AsSingle();
        }
    }
}