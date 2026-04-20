using System;
using UI;
using UnityEngine.SceneManagement;

namespace Utilites
{
    public class SceneController :IDisposable
    {
        private DeathUIPresenter _deathUIPresenter;

        public SceneController(DeathUIPresenter deathUIPresenter)
        {
            _deathUIPresenter = deathUIPresenter;

            _deathUIPresenter.SubscribeToRestartGame(ReloadGame);
        }

        public void Dispose()
        {
            _deathUIPresenter.UnSubscribeToRestartGame(ReloadGame);
        }

        private void ReloadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}