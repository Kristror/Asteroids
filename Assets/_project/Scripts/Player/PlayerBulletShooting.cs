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

        private const float _timeToLive = 2;

        private float _timeOflastShot = 0;
        private BulletFactory _bulletFactory;
        private PlayerInputController _playerInputController;
        private PlayerStatisticsController _playerStatisticsController;

        [Inject]
        public void Construct(PlayerInputController inputController,PlayerStatisticsController playerStatisticsController, BulletFactory bulletFactory)
        {
            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;
            _bulletFactory = bulletFactory;

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
                GameObject bullet = _bulletFactory.Create().gameObject;

                GameObject.Destroy(bullet, _timeToLive);

                bullet.transform.position = _bulletStartPosition.position;
                bullet.transform.rotation = _bulletStartPosition.rotation;

                _playerStatisticsController.ShotBullet();

                _timeOflastShot = Time.time;
            }
        }
    }
}