using Player;
using UI;
using UnityEngine;

namespace Utilites
{
    public class TimeController
    {
        public TimeController(PlayerController playerController, UIManager uIController)
        {
            playerController.PlayerDeath += StopTime;
            uIController.RestartGame += ResumeTime;
        }

        private void StopTime()
        {
            Time.timeScale = 0;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1;
        }
    }
}