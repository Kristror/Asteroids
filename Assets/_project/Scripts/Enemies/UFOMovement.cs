using Player;
using UnityEngine;
using Utilities;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UFOMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _ufoMovementSpeed;

        private Rigidbody2D _rigidbody;
        private PlayerProvider _playerProvider;
        private BorderController _borderController;

        [Inject]
        private void Construct(PlayerProvider playerProvider, BorderController borderController)
        {
            _playerProvider = playerProvider;
            _borderController = borderController;
        }

        private void Start()
        {
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