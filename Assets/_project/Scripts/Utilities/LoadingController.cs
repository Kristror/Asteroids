using Utilities.AssetLoading;

namespace Utilities
{
    public class LoadingController
    {
        private AssetsProvider _assetsProvider;
        private SceneLoader _sceneLoader;

        public LoadingController (AssetsProvider assetsProvider, SceneLoader sceneLoader)
        {
            _assetsProvider = assetsProvider;
            _sceneLoader = sceneLoader;
        }

        public async void LoadMainMenu()
        {
            if (!_assetsProvider.IsMainMenuAssetsLoaded)
            {
                await _assetsProvider.LoadMainMenuAssets();
            }

            _sceneLoader.LoadMainMenu();
        }

        public async void LoadGame()
        {
            if (!_assetsProvider.IsGameAssetsLoaded)
            {
                await _assetsProvider.LoadGameAssets();
            }

            _sceneLoader.LoadGame();
        }
    }
}