using Cysharp.Threading.Tasks;
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

        public void LoadMainMenu()
        {
            UniTaskVoid loadMenu = LoadAndOpenMainMenu();
        }

        public void LoadGame()
        {

            UniTaskVoid loadGame = LoadAndOpenGame();
        }

        private async UniTaskVoid LoadAndOpenMainMenu()
        {
            if (!_assetsProvider.IsMainMenuAssetsLoaded)
            {
                await _assetsProvider.LoadMainMenuAssets();
            }

            _sceneLoader.LoadMainMenu();
        }

        private async UniTaskVoid LoadAndOpenGame()
        {
            if (!_assetsProvider.IsGameAssetsLoaded)
            {
                await _assetsProvider.LoadGameAssets();
            }

            _sceneLoader.LoadGame();
        }
    }
}