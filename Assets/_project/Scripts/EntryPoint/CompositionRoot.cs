using Enemies;
using Player;
using UI;
using UnityEngine;
using Utilites;

namespace EntryPoint
{
    public class CompositionRoot
    {
        public void Initialize()
        {
            PlayerController playerController = new PlayerController();
            EnemiesController enemiesController = new EnemiesController(playerController);

            ScoreController scoreController = new ScoreController(enemiesController);
            UIController uiController = new UIController(playerController, scoreController);

            TimeController timeController = new TimeController(playerController, uiController);
            SceneController sceneController = new SceneController(uiController);
        }
    }
}