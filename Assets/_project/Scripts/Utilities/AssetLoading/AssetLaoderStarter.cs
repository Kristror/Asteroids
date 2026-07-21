using UnityEngine;
using Zenject;
using Utilites;

namespace AssetLoading
{
    public class AssetLaoderStarter : MonoBehaviour
    {
        [Inject] private AssetsProvider _assetsProvider;
        [Inject] private SceneLoader _sceneLoader;

        private async void Start()
        {
            await _assetsProvider.LoadMainMenuAssets();

            _sceneLoader.StartMainMenu();
        }
    }
}