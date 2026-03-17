using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Player
{
    public class PlayerBulletShooting : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _shootingSpeed;
        [SerializeField] private Transform _bulletStartPosition;

        private float _timeOflastShot = 0;
        private BulletSpawner _bulletFactory;

        private void Start()
        {
            _bulletFactory = new BulletSpawner();
        }
        public void SetDependencies(PlayerInputController inputController)
        {
            inputController.ShootBullet += Shoot;
        }

        private void Shoot()
        {
            bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed)
            {
                _bulletFactory.SpawnBullet(_bulletStartPosition);

                _timeOflastShot = Time.time;
            }
        }
    }
}