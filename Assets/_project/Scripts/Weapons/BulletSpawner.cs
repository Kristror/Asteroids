using UnityEngine;

namespace Weapons
{
    public class BulletSpawner
    {
        private GameObject _bulletObject;
        private const float _timeToLive = 2;

        public BulletSpawner()
        {
            _bulletObject = Resources.Load<GameObject>("Bullet");
        }

        public void SpawnBullet(Transform bulletStartPosition)
        {
            GameObject bullet = GameObject.Instantiate(_bulletObject, bulletStartPosition.position, bulletStartPosition.rotation);

            GameObject.Destroy(bullet, _timeToLive);
        }
    }
}