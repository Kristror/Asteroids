using UnityEngine;
using Utilites;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _asteroidMovementSpeed;

        private Rigidbody2D _rigidBody;
        private BorderController _borderController;

        [Inject]
        public void Construct(BorderController borderController)
        {
            _borderController = borderController;

        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            CheckBorder();
        }

        public void MultiplySpeed(float multiplier)
        {
            float newSpeed = _asteroidMovementSpeed * multiplier;

            if (newSpeed > 0)
            {
                _asteroidMovementSpeed = newSpeed;
            }
        }

        private void Move()
        {
            _rigidBody.AddForce((transform.up * _asteroidMovementSpeed), ForceMode2D.Force);
        }

        private void CheckBorder()
        {
            Vector2 newPosition = _borderController.CheckIfObjectOnBorder(transform.position);

            if (newPosition != Vector2.zero)
            {
                transform.position = newPosition;
            }
        }
    }
}