using UnityEngine;
using Weapons;
using Zenject;

namespace Player
{
    public class PlayerLazerShooting : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _maxAmmo;
        [SerializeField, Min(0)] private float _timeToReload;
        [SerializeField, Min(0)] private float _shootingSpeed;
        [SerializeField, Min(0)] private float _lazerDuration;
        [SerializeField] private GameObject _lazerObject;

        public int Ammo { get; private set; }

        private float _timeOflastShot = 0;
        private float _timeOfReloadStart = 0;

        private bool _isReloading = false;
        private Lazer _lazer;
        private PlayerInputController _playerInputController;

        [Inject]
        public void Construct(PlayerInputController inputController)
        {
            _playerInputController = inputController;
            _playerInputController.ShootLazer += ShootLazer;
        }

        private void Start()
        {
            Ammo = _maxAmmo;
            _lazer = _lazerObject.GetComponent<Lazer>();
            _lazer.SetLazerDuration(_lazerDuration);
        }

        private void Update()
        {
            Reload();
        }

        private void OnDestroy()
        {
            _playerInputController.ShootLazer -= ShootLazer;
        }

        public float TimeToReload()
        {
            float reloadTime = (_timeToReload - (Time.time - _timeOflastShot));

            if (reloadTime > 0)
            {
                return reloadTime;
            }

            return 0;
        }

        private void Reload()
        {
            if (!_isReloading)
            {
                if (Ammo < _maxAmmo)
                {
                    _timeOfReloadStart = Time.time;
                    _isReloading = true;
                }
            }
            else
            {
                if (_timeToReload < Time.time - _timeOfReloadStart)
                {
                    Ammo++;
                    _isReloading = false;
                }
            }
        }

        private void ShootLazer()
        {
            bool isEnoughTimePassed = _timeOflastShot < Time.time - _shootingSpeed;

            if (isEnoughTimePassed && (Ammo > 0))
            {
                _lazer.Shoot();
                Ammo--;
                _timeOflastShot = Time.time;
            }
        }
    }
}