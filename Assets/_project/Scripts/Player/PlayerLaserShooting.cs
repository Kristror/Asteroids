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

        [SerializeField, Min(1)] private int _maxAmmo;
        [SerializeField, Min(0)] private int _timeToReload;
        [SerializeField, Min(0)] private float _shootingSpeed;
        [SerializeField, Min(0)] private int _laserDuration;
        [SerializeField] private Laser _laser;

        private float _timeOflastShot = 0;

        private PlayerStatisticsController _playerStatisticsController;
        private AnalyticsController _analyticsController;
        private PlayerInputController _playerInputController;

        [Inject]
        private void Construct(PlayerInputController inputController, PlayerStatisticsController playerStatisticsController, AnalyticsController analyticsController)
        {
            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;
            _analyticsController = analyticsController;
        }

        private void Awake()
        {
            _playerInputController.ShootLaser += ShootLaser;
        }

        private void Start()
        {
            CleanCTS();
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


        public float ShootingCooldown()
        {
            float cooldown = (_shootingSpeed - (Time.time - _timeOflastShot));

            if (cooldown > 0)
            {
                return cooldown;
            }

            return 0;
        }

        private void CleanCTS()
        {
            if (Cts != null && !Cts.IsCancellationRequested)
            {
                Cts.Cancel();
                Cts?.Dispose();
            }
        }

        private async UniTaskVoid ReloadAmmo()
        {
            while (true)
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
    }
}