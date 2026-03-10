using Enemies;
using Player;
using UI;
using Utilites;

namespace EntryPoint
{
    public class CompositionRoot
    {
        public void Initialize()
        {
            PlayerController playerController = new PlayerController();
            ScoreController scoreController = new ScoreController();

            EnemiesController enemiesController = new EnemiesController(playerController, scoreController);
            UIController uiController = new UIController(playerController, scoreController);

            TimeController timeController = new TimeController(playerController, uiController);
            SceneController sceneController = new SceneController(uiController);
        }
    }
}