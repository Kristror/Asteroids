using UnityEngine;

public class PlayerBulletShooting : MonoBehaviour
{
    [SerializeField] private float _shootingSpeed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletStartPosition;

    private float _timeOflastShot = 0;

    void Update()
    {
        bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;
        if (Input.GetMouseButtonDown(0) && isEnoughTimePassed)
        {
            GameObject bullet =GameObject.Instantiate(_bulletPrefab);

            bullet.transform.position = _bulletStartPosition.position;
            bullet.transform.rotation = _bulletStartPosition.rotation;

            _timeOflastShot = Time.time;
        }
    }
}
