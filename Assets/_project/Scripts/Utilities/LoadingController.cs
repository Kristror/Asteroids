using Utilities.AssetLoading;
using Zenject;

namespace Utilities
{
    public class LoadingController
    {
        [Inject] private AssetsProvider _assetsProvider;
        [Inject] private SceneLoader _sceneLoader;

        public async void LoadMainMenu()
        {
            if (!_assetsProvider.isMainMenuAssetsLoaded)
            {
                await _assetsProvider.LoadMainMenuAssets();
            }

            _sceneLoader.LoadMainMenu();
        }

        public async void LoadGame()
        {
            if (!_assetsProvider.isGameAssetsLoaded)
            {
                await _assetsProvider.LoadGameAssets();
            }

            _sceneLoader.LoadGame();
        }
    }
}