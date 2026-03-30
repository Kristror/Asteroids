using System;
using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        public Action PlayerDeath 
        {
            get { return _playerCollision.PlayerDeath; }
            set { _playerCollision.PlayerDeath = value; }
        }

        public GameObject PlayerInstance { get; private set; }

        private PlayerCollision _playerCollision;

        public PlayerController(PlayerFactory playerFactory)
        {
            PlayerInstance = playerFactory.Create().gameObject;

            _playerCollision = PlayerInstance.GetComponentInChildren<PlayerCollision>();
        }
    }
}