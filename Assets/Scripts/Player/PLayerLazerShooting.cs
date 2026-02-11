using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerLazerShooting : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxAmmo;
    [SerializeField, Min(0)] private float _timeToReload;
    [SerializeField, Min(0)] private float _shootingSpeed;
    [SerializeField, Min(0)] private float _lazerDuration;
    [SerializeField] private GameObject _lazerObject;

    private int _ammo;

    public int Ammo => _ammo;

    private float _timeOflastShot = 0;
    private float _timeOfReloadStart = 0;

    private bool _isReloading = false;
    private Lazer _lazer;

    private Mouse _mouse;

    public float TimeToReload()
    {
        float reloadTime = (_timeToReload - (Time.time - _timeOflastShot));
        if (reloadTime > 0)
        {
            return reloadTime;
        }

        return 0;
    }
    private void Start()
    {
        _ammo = _maxAmmo;
        _lazer = _lazerObject.GetComponent<Lazer>();
        _lazer.SetLazerDuration(_lazerDuration);

        _mouse = Mouse.current;
    }

    private void Update()
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
            _lazer.Shoot();
            _ammo--;
            _timeOflastShot = Time.time;
        }
    }
}