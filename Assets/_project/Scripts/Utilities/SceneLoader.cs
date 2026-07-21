using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Utilities;

namespace Utilites
{
    public class SceneLoader
    {
        private SceneList _sceneList;

        public SceneLoader()
        {
            _sceneList = new();
        }

        public void StartMainMenu()
        {
            Addressables.LoadSceneAsync(_sceneList.MainMenu, LoadSceneMode.Additive);
        }

        public void LoadMainMenu()
        {
            Addressables.LoadSceneAsync(_sceneList.MainMenu, LoadSceneMode.Single);
        }

        public void LoadGame()
        {
            Addressables.LoadSceneAsync(_sceneList.Game, LoadSceneMode.Single);
        }
    }
}