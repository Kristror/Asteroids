using Player;
using UnityEngine;
using Utilites;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UFOMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _ufoMovementSpeed;

        private Rigidbody2D _rigidbody;
        private Transform _playerTransform;
        private BorderController _borderController;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveToPlayer();
            CheckBorder();
        }

        [Inject]
        public void Construct(PlayerController playerController, BorderController borderController)
        {
            _playerTransform = playerController.PlayerInstance.transform;
            _borderController = borderController;
        }

        private void MoveToPlayer()
        {
            Vector2 direction = (_playerTransform.position - transform.position).normalized;

            _rigidbody.AddForce(direction * _ufoMovementSpeed, ForceMode2D.Force);
        }

        private void CheckBorder()
        {
            Vector2 newPosition = _borderController.CheckIfObjectOnBorder(transform.position);

            if (newPosition != Vector2.zero)
            {
                _rigidbody.position = newPosition;
            }
        }
    }
}