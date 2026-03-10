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

        private PlayerCollision _playerCollision;

        public GameObject PlayerInstance { get; private set; }

        public PlayerController()
        {
            GameObject _prefabPlayer = Resources.Load<GameObject>("Player");

            //передвать ввод отдельно в классы

            PlayerInstance = GameObject.Instantiate(_prefabPlayer);

            _playerCollision = PlayerInstance.GetComponentInChildren<PlayerCollision>();
        }
    }
}