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

        [Inject]
        public void Construct(PlayerInputController inputController, BulletFactory bulletFactory)
        {
            _playerInputController = inputController;
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

                _timeOflastShot = Time.time;
            }
        }
    }
}