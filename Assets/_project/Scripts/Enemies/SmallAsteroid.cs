using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(AsteroidMovement))]
    public class SmallAsteroid : BaseEnemy
    {
        [SerializeField, Min(1)] private float _asteroidSpeedMult;

        private AsteroidMovement _asteroidMovement;

        private void Awake()
        {
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