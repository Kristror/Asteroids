using System;
using Zenject;

namespace UI
{
    public class GameUIPresenterInitializer : IInitializable, IDisposable
    {
        private PlayerStatsUIPresenter _playerStatsUIPresenter;
        private DeathUIPresenter _deathUIPresenter;
        private PlayerRevivePresenter _playerRevivePresenter;

        private PlayerStatsUIViewFactory _playerStatsUIViewFactory;
        private DeathUIViewFactory _deathUIViewFactory;
        private PlayerReviveViewFactory _playerReviveViewFactory;

        public GameUIPresenterInitializer(
            PlayerStatsUIViewFactory playerStatsUIViewFactory, DeathUIViewFactory deathUIViewFactory, PlayerReviveViewFactory playerReviveViewFactory,
            PlayerStatsUIPresenter playerStatsUIPresenter, DeathUIPresenter deathUIPresenter, PlayerRevivePresenter playerRevivePresenter)
        {
            _playerStatsUIViewFactory = playerStatsUIViewFactory;
            _deathUIViewFactory = deathUIViewFactory;
            _playerReviveViewFactory = playerReviveViewFactory;

            _playerStatsUIPresenter = playerStatsUIPresenter;
            _deathUIPresenter = deathUIPresenter;
            _playerRevivePresenter = playerRevivePresenter;
        }

        public void Initialize()
        {
            PlayerStatsUIView playerStatsUIView = _playerStatsUIViewFactory.Create();
            DeathUIView deathUIView = _deathUIViewFactory.Create();
            PlayerReviveView playerReviveView = _playerReviveViewFactory.Create();

            _playerStatsUIPresenter.SetView(playerStatsUIView);
            _deathUIPresenter.SetView(deathUIView);
            _playerRevivePresenter.SetView(playerReviveView);
        }
        public void Dispose()
        {
            _deathUIPresenter.Dispose();
        }

    }
}