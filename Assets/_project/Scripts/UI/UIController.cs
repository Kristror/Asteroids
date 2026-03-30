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

        public UIController(PlayerController playerController, ScoreController scoreController, UIFactory uIFactory)
        {
            GameObject ui = uIFactory.Create().gameObject;

            _deathUI = ui.GetComponent<DeathScreenUI>();
        }
    }
}