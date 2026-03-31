using UI;
using UnityEngine.SceneManagement;

namespace Utilites
{
    public class SceneController
    {
        public SceneController(UIManager uIController)
        {
            uIController.RestartGame += ReloadGame;
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}