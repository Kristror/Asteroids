using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerObject : IInitializable
    {
        public Vector3 PlayerPosition => PlayerInstance.transform.position;
        public float PlayerRotation => PlayerInstance.transform.rotation.eulerAngles.z;
        public float PlayerSpeed => _playerRigidBody.linearVelocity.magnitude;

        public GameObject PlayerInstance { get; private set; }
        public PlayerCollision PlayerCollision { get; private set; }
        public PlayerLazerShooting PlayerLazerShooting { get; private set; }

        private Rigidbody2D _playerRigidBody;
        private PlayerShipFactory _PlayerShipFactory;

        public PlayerObject(PlayerShipFactory playerShipFactory)
        {
            _PlayerShipFactory = playerShipFactory;
        }

        public void Initialize()
        {
            PlayerInstance = _PlayerShipFactory.Create().gameObject;

            _playerRigidBody = PlayerInstance.GetComponent<Rigidbody2D>();

            PlayerCollision = PlayerInstance.GetComponentInChildren<PlayerCollision>();

            PlayerLazerShooting = PlayerInstance.GetComponent<PlayerLazerShooting>();
            
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