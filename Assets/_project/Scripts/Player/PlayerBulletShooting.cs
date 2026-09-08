using Configs;
using PlayerAnalytics;
using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerBulletShooting : MonoBehaviour
    {
        [SerializeField] private Transform _bulletStartPosition;
        private float _shootingSpeed;
        private int _bulletPoolSize;

        private float _timeOfLastShot = 0;

        private BulletPool _bulletPool;
        private PlayerInputController _playerInputController;
        private PlayerStatisticsController _playerStatisticsController;
        private ConfigsController _configController;

        [Inject]
        private void Construct(PlayerInputController inputController, PlayerStatisticsController playerStatisticsController, BulletPool bulletPool, ConfigsController configsController)
        {
            _playerInputController = inputController;
            _configController = configsController;
            _playerStatisticsController = playerStatisticsController;

            _bulletPool = bulletPool;
        }

        private void Start()
        {
            _shootingSpeed = _configController.GetBulletShootingSpeed();
            _bulletPoolSize = _configController.GetBulletPoolSize();

            _bulletPool.FillPool(_bulletPoolSize);
        }

        private void Awake()
        {
            _playerInputController.ShootBullet += Shoot;
        }

        private void OnDestroy()
        {
            _playerInputController.ShootBullet -= Shoot;
        }

        private void Shoot()
        {
            bool isEnoughTimePassed = _timeOfLastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed)
            {
                BulletMovement bullet = _bulletPool.Next();

                bullet.StartMovementFromPoint(_bulletStartPosition);                

                _playerStatisticsController.ShotBullet();

                _timeOfLastShot = Time.time;
            }
        }
    }
}