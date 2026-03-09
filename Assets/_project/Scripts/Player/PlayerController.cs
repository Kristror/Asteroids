using System;
using UnityEditor;
using UnityEngine;
using Utilites;

namespace Player
{
    public class PlayerController
    {
        public Action PlayerDeath;

        private PlayerCollision _playerCollision;
        private TimeController _timeController;

        public GameObject playerInstance { get; private set; }

        public PlayerController()
        {
            GameObject _prefabPlayer = Resources.Load<GameObject>("Player");

            //передвать ввод отдельно в классы

            playerInstance = GameObject.Instantiate(_prefabPlayer);

            _playerCollision = playerInstance.GetComponentInChildren<PlayerCollision>();

            _playerCollision.SetAction(PlayerDeath);
        }
    }
}