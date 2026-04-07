using System;
using UI;
using UnityEngine.SceneManagement;

namespace Utilites
{
    public class SceneController :IDisposable
    {
        private UIManager _uIManager;
        public SceneController(UIManager uIManager)
        {
            _uIManager = uIManager;

            _uIManager.DeathUIpresenter.DeathUIModel.RestartGame += ReloadGame;
        }

        public void Dispose()
        {
            _uIManager.DeathUIpresenter.DeathUIModel.RestartGame -= ReloadGame;
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}