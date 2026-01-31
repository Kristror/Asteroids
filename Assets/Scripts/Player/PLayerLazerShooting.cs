using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerLazerShooting : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxAmmo;
    [SerializeField, Min(0)] private float _timeToReload;
    [SerializeField, Min(0)] private float _shootingSpeed;
    [SerializeField] private GameObject _lazerObject;

    private int _ammo;

    private float _timeOflastShot = 0;
    private float _timeOfReloadStart = 0;

    private bool _isReloading = false;
    private Lazer lazer;

    private Mouse _mouse;

    private void Start()
    {
        _ammo = _maxAmmo;
        lazer = _lazerObject.GetComponent<Lazer>();

        _mouse = Mouse.current;
    }

    void Update()
    {
        LazerShooting();
        Reload();
    }

    private void Reload()
    {
        if (!_isReloading)
        {
            if (_ammo < _maxAmmo)
            {
                _timeOfReloadStart = Time.time;
                _isReloading = true;
            }
        }
        else
        {
            if (_timeToReload < Time.time - _timeOfReloadStart)
            {
                _ammo++;
                _isReloading = false;
            }
        }
    }

    private void LazerShooting()
    {
        bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

        if (_mouse.rightButton.wasPressedThisFrame && isEnoughTimePassed && (_ammo > 0))
        {
            lazer.Shoot();
            _ammo--;
            _timeOflastShot = Time.time;
        }
    }
}