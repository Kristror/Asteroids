using Player;
using System;
using UnityEngine;
using Utilites;

namespace UI
{
    public class UIController
    {
        public Action RestartGame;

        public UIController(PlayerController playerController, ScoreController scoreController)
        {
            GameObject _uiPrefab = Resources.Load<GameObject>("GameUI");
            GameObject ui = GameObject.Instantiate(_uiPrefab);

            ui.GetComponentInChildren<DeathScreenUI>().SetDependencies(playerController, scoreController, RestartGame);
            ui.GetComponentInChildren<UIplayerStats>().SetPlayer(playerController.playerInstance);
        }
    }
}