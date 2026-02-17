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

    private void Update()
    {
        Shoot ();
    }

    private void Shoot()
    {
        bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

        if (_mouse.leftButton.wasPressedThisFrame && isEnoughTimePassed)
        {
            GameObject bullet = GameObject.Instantiate(_bulletPrefab);

            bullet.GetComponent<BulletMovement>().Shoot(_bulletStartPosition);
            
            _timeOflastShot = Time.time;
        }
    }
}
