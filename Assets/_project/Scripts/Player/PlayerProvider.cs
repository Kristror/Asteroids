using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerProvider : IInitializable
    {
        public Vector3 PlayerPosition => _playerInstance.transform.position;
        public float PlayerRotation => _playerInstance.transform.rotation.eulerAngles.z;
        public float PlayerSpeed => _rigidBody.linearVelocity.magnitude;
        public PlayerCollision PlayerCollision { get; private set; }
        public PlayerLazerShooting PlayerLazerShooting { get; private set; }


        private GameObject _playerInstance;
        private Rigidbody2D _rigidBody;
        private PlayerShipFactory _playerShipFactory;

        public PlayerProvider(PlayerShipFactory playerShipFactory)
        {
            _playerShipFactory = playerShipFactory;
        }

        public void Initialize()
        {
            _playerInstance = _playerShipFactory.Create().gameObject;

            _rigidBody = _playerInstance.GetComponent<Rigidbody2D>();

            PlayerCollision = _playerInstance.GetComponentInChildren<PlayerCollision>();

            PlayerLazerShooting = _playerInstance.GetComponent<PlayerLazerShooting>();
            
        }

        public void SubscribeToPlayerDeath(Action func)
        {
            PlayerCollision.PlayerDeath += func;
        } 

        public void UnSubscribeToPlayerDeath(Action func)
        {
            PlayerCollision.PlayerDeath -= func;
        }
    }
}