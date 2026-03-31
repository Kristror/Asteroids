using Player;
using System;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIManager : ITickable
    {
        public Action RestartGame 
        {
            get { return _deathUI.RestartGame; }
            set { _deathUI.RestartGame = value; }
        }

        private DeathUIModel _deathUI;
        private PlayerStatsUIPresenter _playerStatsUIPresenter;

        public UIManager(PlayerController playerController, PlayerStatsUIModel playerStatsUIModel, DeathUIModel deathUIModel, UIFactory uIFactory)
        {
            GameObject ui = uIFactory.Create().gameObject;

            new DeathUIPresenter(playerController, deathUIModel, ui.GetComponent<DeathUIView>());
            _playerStatsUIPresenter = new PlayerStatsUIPresenter(playerStatsUIModel, ui.GetComponent<PlayerStatsUIView>());

            _deathUI = deathUIModel;
        }

        public void Tick()
        {
            _playerStatsUIPresenter.Tick();
        }
    }
}