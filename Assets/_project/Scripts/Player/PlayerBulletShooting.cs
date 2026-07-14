using PlayerAnalytics;
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
        private BulletPool _bulletPool;
        private int _bulletPollSize = 25;
        private PlayerInputController _playerInputController;
        private PlayerStatisticsController _playerStatisticsController;

        [Inject]
        public void Construct(PlayerInputController inputController,PlayerStatisticsController playerStatisticsController, BulletPool bulletPool)
        {
            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;

            _bulletPool = bulletPool;
            _bulletPool.FillPool(_bulletPollSize);

            _playerInputController.ShootBullet += Shoot;
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
                BulletMovement bullet = _bulletPool.Next();

                bullet.StartMovementFromPoint(_bulletStartPosition);                

                _playerStatisticsController.ShotBullet();

                _timeOflastShot = Time.time;
            }
        }
    }
}