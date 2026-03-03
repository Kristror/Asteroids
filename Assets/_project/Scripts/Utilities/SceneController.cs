using UnityEngine.SceneManagement;

namespace Utilites
{
    public class SceneController
    {
        public void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}