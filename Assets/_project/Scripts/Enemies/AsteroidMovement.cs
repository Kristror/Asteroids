using Configs;
using UnityEngine;
using Utilities;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AsteroidMovement : MonoBehaviour
    {
        private float _asteroidMovementSpeed;

        private Rigidbody2D _rigidbody;
        private ConfigsController _configController;
        private BorderController _borderController;

        [Inject]
        private void Construct(ConfigsController configsController,BorderController borderController)
        {
            _configController = configsController;
            _borderController = borderController;
        }

        private void Start()
        {
            _asteroidMovementSpeed = _configController.GetAsteroidMovementSpeed();

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