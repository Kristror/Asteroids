using Configs;
using Cysharp.Threading.Tasks;
using PlayerAnalytics;
using System.Threading;
using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerLaserShooting : MonoBehaviour
    {
        public int Ammo { get; private set; }

        protected CancellationTokenSource Cts;

        [SerializeField] private Laser _laser;

        private int _maxAmmo;
        private int _timeToReload;
        private float _shootingSpeed;
        private int _laserDuration;

        private float _timeOflastShot = 0;

        private PlayerStatisticsController _playerStatisticsController;
        private AnalyticsController _analyticsController;
        private PlayerInputController _playerInputController;
        private ConfigsController _configController;

        [Inject]
        private void Construct(PlayerInputController inputController, PlayerStatisticsController playerStatisticsController,ConfigsController configsController, AnalyticsController analyticsController)
        {
            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;
            _analyticsController = analyticsController;
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
            float cooldown = (_shootingSpeed - (Time.time - _timeOflastShot));

            if (cooldown > 0)
            {
                return cooldown;
            }

            return 0;
        }

        private void Start()
        {
            Cts = new CancellationTokenSource();

            Ammo = _maxAmmo;

            _laser.SetLaserDuration(_laserDuration);

            UniTaskVoid reloadAmmo = ReloadAmmo();
        }       

        private void OnDestroy()
        {
            _playerInputController.ShootLaser -= ShootLaser;

            CleanCTS();
        }

        private async UniTaskVoid ReloadAmmo()
        {
            while (!Cts.IsCancellationRequested)
            {
                if (Ammo < _maxAmmo)
                {
                    await UniTask.Delay(_timeToReload, cancellationToken: Cts.Token);

                    Ammo++;
                }
                await UniTask.DelayFrame(1);
            }
        }

        private void ShootLaser()
        {
            bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed && (Ammo > 0))
            {
                _laser.Shoot();

                _playerStatisticsController.ShotLaser();
                _analyticsController.LaserUsed();

                Ammo--;
                _timeOflastShot = Time.time;
            }
        }

        private void CleanCTS()
        {
            if (Cts != null && !Cts.IsCancellationRequested)
            {
                Cts.Cancel();
                Cts?.Dispose();
            }
        }

    }
}