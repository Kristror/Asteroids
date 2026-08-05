using Cysharp.Threading.Tasks;
using PlayerAnalytics;
using System.Threading;
using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerLazerShooting : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _maxAmmo;
        [SerializeField, Min(0)] private int _timeToReload;
        [SerializeField, Min(0)] private float _shootingSpeed;
        [SerializeField, Min(0)] private int _lazerDuration;
        [SerializeField] private Lazer _lazer;

        public int Ammo { get; private set; }

        private float _timeOflastShot = 0;

        private PlayerStatisticsController _playerStatisticsController;
        private AnalyticsController _analyticsController;
        private PlayerInputController _playerInputController;

        protected CancellationTokenSource _cts;

        [Inject]
        public void Construct(PlayerInputController inputController, PlayerStatisticsController playerStatisticsController, AnalyticsController analyticsController)
        {
            _cts = new CancellationTokenSource();

            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;
            _analyticsController = analyticsController;

            _playerInputController.ShootLazer += ShootLazer;
        }

        private void Start()
        {
            Ammo = _maxAmmo;

            _lazer.SetLazerDuration(_lazerDuration);

            UniTaskVoid reloadAmmo = ReloadAmmo();
        }       

        private void OnDestroy()
        {
            _playerInputController.ShootLazer -= ShootLazer;

            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }

        private async UniTaskVoid ReloadAmmo()
        {
            while (true)
            {
                if (Ammo < _maxAmmo)
                {
                    await UniTask.Delay(_timeToReload, cancellationToken: _cts.Token);

                    Ammo++;
                }
                await UniTask.DelayFrame(1);
            }
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

        private void ShootLazer()
        {
            bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed && (Ammo > 0))
            {
                _lazer.Shoot();

                _playerStatisticsController.ShotLazer();
                _analyticsController.LazerUsed();

                Ammo--;
                _timeOflastShot = Time.time;
            }
        }
    }
}