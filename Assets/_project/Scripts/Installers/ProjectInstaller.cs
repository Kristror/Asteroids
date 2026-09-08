using Configs;
using PlayerAnalytics;
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
            BindConfigs();
            BindAnalytics();
        }

        private void BindLoaders()
        {
            Container.Bind<IAssetLoader>().To<LocalAddressablesLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<AssetsProvider>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();

            Container.Bind<LoadingController>().AsSingle();
        }

        private void BindAnalytics()
        {
            Container.BindInterfacesAndSelfTo<AnalyticsWithFirebase>().AsSingle();
            Container.BindExecutionOrder<AnalyticsWithFirebase>(-1);
        }

        private void BindConfigs()
        {
            Container.BindInterfacesAndSelfTo<FirebaseRemoteConfigsProvider>().AsSingle();
            Container.BindExecutionOrder<FirebaseRemoteConfigsProvider>(-1);
            Container.BindInterfacesAndSelfTo<ConfigsController>().AsSingle();
        }
    }
}