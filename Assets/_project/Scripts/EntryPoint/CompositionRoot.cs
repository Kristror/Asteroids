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
            BorderController borderController = new BorderController();
            ScoreController scoreController = new ScoreController();

            PlayerController playerController = new PlayerController(borderController);
            EnemiesController enemiesController = new EnemiesController(playerController, scoreController, borderController);
            UIController uiController = new UIController(playerController, scoreController);

            TimeController timeController = new TimeController(playerController, uiController);
            SceneController sceneController = new SceneController(uiController);
        }
    }
}