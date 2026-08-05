using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class SceneLoader
    {
        public void LoadMainMenu()
        {
            Addressables.LoadSceneAsync(SceneList.MainMenu, LoadSceneMode.Single);
        }

        public void LoadGame()
        {
            Addressables.LoadSceneAsync(SceneList.Game, LoadSceneMode.Single);
        }
    }
}