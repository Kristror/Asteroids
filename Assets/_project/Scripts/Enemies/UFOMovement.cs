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
        private PlayerObject _playerObject;
        private BorderController _borderController;

        [Inject]
        public void Construct(PlayerObject playerController, BorderController borderController)
        {
            _playerObject = playerController;
            _borderController = borderController;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveToPlayer();
            CheckBorder();
        }

        private void MoveToPlayer()
        {
            Vector2 direction = (_playerObject.PlayerPosition - transform.position).normalized;

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