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
        [SerializeField] private GameObject _lazerObject;

        public int Ammo { get; private set; }

        private float _timeOflastShot = 0;

        private PlayerStatisticsController _playerStatisticsController;
        private AnalyticsController _analyticsController;
        private Lazer _lazer;
        private PlayerInputController _playerInputController;

        protected CancellationTokenSource _reloadAmmoToken;

        [Inject]
        public void Construct(PlayerInputController inputController, PlayerStatisticsController playerStatisticsController, AnalyticsController analyticsController)
        {
            _playerInputController = inputController;
            _playerStatisticsController = playerStatisticsController;
            _analyticsController = analyticsController;

            _playerInputController.ShootLazer += ShootLazer;
        }

        private void Start()
        {
            Ammo = _maxAmmo;

            _lazer = _lazerObject.GetComponent<Lazer>();
            _lazer.SetLazerDuration(_lazerDuration);

            UniTaskVoid reloadAmmo = ReloadAmmo();
        }       

        private void OnDestroy()
        {
            _playerInputController.ShootLazer -= ShootLazer; 
            _reloadAmmoToken?.Cancel();
            _reloadAmmoToken?.Dispose();
        }

        private async UniTaskVoid ReloadAmmo()
        {
            _reloadAmmoToken = new CancellationTokenSource();

            while (true)
            {
                if (Ammo < _maxAmmo)
                {
                    await UniTask.Delay(_timeToReload, cancellationToken: _reloadAmmoToken.Token);

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