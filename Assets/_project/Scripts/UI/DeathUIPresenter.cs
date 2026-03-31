using Player;

namespace UI
{
    public class DeathUIPresenter 
    {
        private DeathUIModel _deathUIModel;
        private DeathUIView _deathUIView;

        public DeathUIPresenter(PlayerController playerController, DeathUIModel model, DeathUIView view)
        {
            playerController.PlayerDeath += PlayerDeath;

            _deathUIModel = model;
            _deathUIView = view;

            _deathUIView.SetActiveDeathScreen(false);
            _deathUIView.OnClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            _deathUIModel.RestartGame();
        }

        private void PlayerDeath()
        {
            _deathUIView.SetActiveDeathScreen(true);
            _deathUIView.ShowScore(_deathUIModel.PlayerScore);
        }

    }
}