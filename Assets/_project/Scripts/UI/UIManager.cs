using UnityEngine;

namespace UI
{
    public class UIManager 
    {
        private DeathUIPresenter _deathUIpresenter;
        private PlayerStatsUIPresenter _playerStatsUIPresenter;

        public UIManager(UIFactory uIFactory, DeathUIPresenter deathUIPresenter, PlayerStatsUIPresenter playerStatsUIPresenter)
        {
            GameObject ui = uIFactory.Create().gameObject;

            _deathUIpresenter = deathUIPresenter;
            _playerStatsUIPresenter = playerStatsUIPresenter;

            _deathUIpresenter.SetView(ui.GetComponent<DeathUIView>());
            _playerStatsUIPresenter.SetView(ui.GetComponent<PlayerStatsUIView>());
        }
    }
}