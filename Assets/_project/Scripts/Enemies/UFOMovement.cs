using Configs;
using Player;
using UnityEngine;
using Utilities;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UFOMovement : MonoBehaviour
    {
        private float _ufoMovementSpeed;

        private Rigidbody2D _rigidbody;
        private PlayerProvider _playerProvider;
        private ConfigsController _configController;
        private BorderController _borderController;

        [Inject]
        private void Construct(PlayerProvider playerProvider,ConfigsController configsController, BorderController borderController)
        {
            _playerProvider = playerProvider;
            _configController = configsController;
            _borderController = borderController;
        }

        private void Start()
        {
            _ufoMovementSpeed = _configController.GetUfoMovementSpeed();

            _borderController.TrackObject(transform);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            Vector2 direction = (_playerProvider.PlayerPosition - transform.position).normalized;

            _rigidbody.AddForce(direction * _ufoMovementSpeed, ForceMode2D.Force);
        }

        private void OnDestroy()
        {
            _borderController.StopTrackingObject(transform);
        }
    }
}