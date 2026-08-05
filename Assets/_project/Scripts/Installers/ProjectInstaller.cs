using Utilities.AssetLoading;
using Utilities;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoaders();
        }

        private void BindLoaders()
        {
            Container.Bind<IAssetLoader>().To<LocalAddressablesLoader>().AsSingle();
            Container.Bind<AssetsProvider>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();

            Container.Bind<LoadingController>().AsSingle();
        }
    }
}