using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBulletShooting : MonoBehaviour
{
    [SerializeField, Min(0)] private float _shootingSpeed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletStartPosition;

    private float _timeOflastShot = 0;

    private Mouse _mouse;

    private void Start()
    {
        _mouse = Mouse.current;
    }

    void Update()
    {
        Shoot ();
    }

    private void Shoot()
    {
        bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

        if (_mouse.leftButton.isPressed && isEnoughTimePassed)
        {
            GameObject bullet = GameObject.Instantiate(_bulletPrefab);

            bullet.transform.position = _bulletStartPosition.position;
            bullet.transform.rotation = _bulletStartPosition.rotation;

            _timeOflastShot = Time.time;
        }
    }
}
