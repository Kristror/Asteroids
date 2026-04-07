using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerBulletShooting : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _shootingSpeed;
        [SerializeField] private Transform _bulletStartPosition;

        private float _timeOflastShot = 0;
        private BulletSpawner _bulletFactory;
        private PlayerInputController _playerInputController;

        [Inject]
        public void Construct(PlayerInputController inputController)
        {
            _playerInputController = inputController;

            _playerInputController.ShootBullet += Shoot;
        }

        private void Start()
        {
            _bulletFactory = new BulletSpawner();
        }

        private void OnDestroy()
        {
            _playerInputController.ShootBullet -= Shoot;
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