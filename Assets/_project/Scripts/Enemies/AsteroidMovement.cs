using UnityEngine;
using Utilities;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _asteroidMovementSpeed;

        private Rigidbody2D _rigidbody;
        private BorderController _borderController;

        [Inject]
        private void Construct(BorderController borderController)
        {
            _borderController = borderController;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _borderController.TrackObject(transform);
        }

        private void FixedUpdate()
        {
            Move();
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
            _rigidbody.AddForce((transform.up * _asteroidMovementSpeed), ForceMode2D.Force);
        }

        private void OnDestroy()
        {
            _borderController.StopTrackingObject(transform);
        }
    }
}