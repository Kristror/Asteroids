using Zenject;

namespace UI
{
    public class UIPresenterInitializer : IInitializable
    {
        private DeathUIPresenter _deathUIPresenter;
        private PlayerStatsUIPresenter _playerStatsUIPresenter;

        private PlayerStatsUIViewFactory _playerStatsUIViewFactory;
        private DeathUIViewFactory _deathUIViewFactory;

        public UIPresenterInitializer(PlayerStatsUIViewFactory playerStatsUIViewFactory, DeathUIViewFactory deathUIViewFactory, DeathUIPresenter deathUIPresenter, PlayerStatsUIPresenter playerStatsUIPresenter)
        {
            _playerStatsUIViewFactory = playerStatsUIViewFactory;
            _deathUIViewFactory = deathUIViewFactory;

            _deathUIPresenter = deathUIPresenter;
            _playerStatsUIPresenter = playerStatsUIPresenter;
        }

        public void Initialize()
        {
            PlayerStatsUIView playerStatsUIView = _playerStatsUIViewFactory.Create();
            DeathUIView deathUIView = _deathUIViewFactory.Create();

            _deathUIPresenter.SetView(deathUIView);
            _playerStatsUIPresenter.SetView(playerStatsUIView);
        }
    }
}