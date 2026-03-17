using System;
using UnityEngine;
using Utilites;

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

        public PlayerController(BorderController borderController)
        {
            GameObject _prefabPlayer = Resources.Load<GameObject>("Player");

            PlayerInstance = GameObject.Instantiate(_prefabPlayer);

            _playerCollision = PlayerInstance.GetComponentInChildren<PlayerCollision>();

            PlayerInputController inputController = PlayerInstance.GetComponent<PlayerInputController>();

            PlayerInstance.GetComponent<PlayerMovement>().SetDependencies(inputController ,borderController);
            PlayerInstance.GetComponent<PlayerBulletShooting>().SetDependencies(inputController);
            PlayerInstance.GetComponent<PlayerLazerShooting>().SetDependencies(inputController);
        }
    }
}