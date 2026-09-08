using Configs;
using UnityEngine;
using Zenject;

namespace Enemies
{
    [RequireComponent(typeof(AsteroidMovement))]
    public class SmallAsteroid : Enemy
    {
        private float _asteroidSpeedMult;

        private AsteroidMovement _asteroidMovement;
        private ConfigsController _configController;

        [Inject]
        private void Construct(ConfigsController configsController)
        {
            _configController = configsController;
        }

        private void Start()
        {
            _asteroidSpeedMult = _configController.GetAsteroidSpeedMult();
            _asteroidMovement = GetComponent<AsteroidMovement>();

            RotateAtRandomAngle();
            MultiplySpeed();
        }

        private void MultiplySpeed()
        {
            _asteroidMovement.MultiplySpeed(_asteroidSpeedMult);
        }

        private void RotateAtRandomAngle()
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }
}