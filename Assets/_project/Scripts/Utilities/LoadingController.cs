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
        
        public void LoadStore()
        {
            UniTaskVoid loadstore = LoadAndOpenStore();
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

        private async UniTaskVoid LoadAndOpenStore()
        {
            if (!_assetsProvider.IsStoreAssetsLoaded)
            {
                await _assetsProvider.LoadStoreAssets();
            }

            _sceneLoader.LoadStore();
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