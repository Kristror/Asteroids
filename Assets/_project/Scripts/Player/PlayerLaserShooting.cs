using Configs;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerLaserShooting : MonoBehaviour
    {
        public int Ammo { get; private set; }

        [SerializeField] private Laser _laser;

        public event Action LaserFired;

        private int _maxAmmo;
        private int _timeToReload;
        private float _shootingSpeed;
        private int _laserDuration;
        private float _timeOfLastShot = 0;
        private bool _isReloading = false;

        private PlayerInputController _playerInputController;
        private ConfigsController _configController;
        private CancellationTokenSource _cts;


        [Inject]
        private void Construct(PlayerInputController inputController,ConfigsController configsController)
        {
            _playerInputController = inputController;
            _configController = configsController;
        }

        private void Awake()
        {
            _maxAmmo = _configController.GetLaserMaxAmmo();
            _timeToReload = _configController.GetLaserTimeToReload();
            _shootingSpeed = _configController.GetLaserShootingSpeed();
            _laserDuration = _configController.GetLaserDuration();

            _playerInputController.ShootLaser += ShootLaser;
        }

        public float ShootingCooldown()
        {
            float cooldown = (_shootingSpeed - (Time.time - _timeOfLastShot));

            if (cooldown > 0)
            {
                return cooldown;
            }

            return 0;
        }

        private void Start()
        {
            Ammo = _maxAmmo;

            _laser.SetLaserDuration(_laserDuration);
        }       

        private void OnDestroy()
        {
            _playerInputController.ShootLaser -= ShootLaser;

            CleanCTS();
        }

        private async UniTaskVoid ReloadAmmo()
        {
            _isReloading = true;

            while (!_cts.IsCancellationRequested && _isReloading)
            {
                if (Ammo < _maxAmmo)
                {
                    await UniTask.Delay(_timeToReload, cancellationToken: _cts.Token);

                    Ammo++;
                }
                else
                {
                    _isReloading = false;
                }
            }
        }

        private void ShootLaser()
        {
            bool isEnoughTimePassed = _timeOfLastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed && (Ammo > 0))
            {
                _laser.Shoot();
                LaserFired?.Invoke();

                Ammo--;
                _timeOfLastShot = Time.time;

                if (!_isReloading)
                {
                    _cts = new CancellationTokenSource();

                    UniTaskVoid reload = ReloadAmmo();
                }
            }
        }

        private void CleanCTS()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }

    }
}