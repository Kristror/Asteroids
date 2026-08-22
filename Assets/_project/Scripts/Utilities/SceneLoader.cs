using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class SceneLoader
    {
        public void LoadMainMenu()
        {
            Addressables.LoadSceneAsync(SceneList.MAIN_MENU, LoadSceneMode.Single);
        }

        public void LoadGame()
        {
            Addressables.LoadSceneAsync(SceneList.GAME, LoadSceneMode.Single);
        }
    }
}