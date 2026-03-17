using UnityEngine;
using Utilites;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UFOMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _ufoMovementSpeed;

        private Rigidbody2D _rigidbody;
        private Transform _playerObject;
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

        public void SetDependencies(GameObject playerObject, BorderController borderController)
        {
            _playerObject = playerObject.transform;
            _borderController = borderController;
        }

        private void MoveToPlayer()
        {
            Vector2 direction = (_playerObject.position - transform.position).normalized;

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