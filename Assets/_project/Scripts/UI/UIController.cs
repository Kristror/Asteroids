using Player;
using System;
using UnityEngine;
using Utilites;

namespace UI
{
    public class UIController
    {
        public Action RestartGame 
        {
            get { return _deathUI.RestartGame; }
            set { _deathUI.RestartGame = value; }
        }

        private DeathScreenUI _deathUI;

        public UIController(PlayerController playerController, ScoreController scoreController)
        {
            GameObject _uiPrefab = Resources.Load<GameObject>("GameUI");
            GameObject ui = GameObject.Instantiate(_uiPrefab);


            _deathUI = ui.GetComponentInChildren<DeathScreenUI>();
            _deathUI.SetDependencies(playerController, scoreController);
            ui.GetComponentInChildren<UIplayerStats>().SetPlayer(playerController.PlayerInstance);
        }
    }
}