using Player;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIManager : ITickable
    {
        public DeathUIPresenter DeathUIpresenter;
        private PlayerStatsUIPresenter _playerStatsUIPresenter;

        public UIManager(PlayerController playerController, PlayerStatsUIModel playerStatsUIModel, DeathUIModel deathUIModel, UIFactory uIFactory)
        {
            GameObject ui = uIFactory.Create().gameObject;

            DeathUIpresenter = new DeathUIPresenter(playerController, deathUIModel, ui.GetComponent<DeathUIView>());
            _playerStatsUIPresenter = new PlayerStatsUIPresenter(playerStatsUIModel, ui.GetComponent<PlayerStatsUIView>());
        }

        public void Tick()
        {
            _playerStatsUIPresenter.Tick();
        }
    }
}