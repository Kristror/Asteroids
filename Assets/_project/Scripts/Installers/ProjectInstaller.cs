using AssetLoading;
using Utilites;
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
            Container.Bind<IAssetLoader>().To<LoacalAddressablesLoader>().AsSingle();
            Container.Bind<AssetsProvider>().AsSingle();

            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}