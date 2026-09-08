using Configs;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        private int _timeToLive;
        private float _bulletMovementSpeed;

        private Rigidbody2D _rigidbody;
        private ConfigsController _configController;
        private CancellationTokenSource _cts;

        [Inject]
        public void Construct(ConfigsController configsController)
        {
            _configController = configsController;
        }

        private void Awake()
        {
            _timeToLive = _configController.GetBulletTimeToLive();
            _bulletMovementSpeed = _configController.GetBulletMovementSpeed();

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void StartMovementFromPoint(Transform startPosition)
        {
            CleanCTS();
            _cts = new CancellationTokenSource();

            transform.position = startPosition.position;
            transform.rotation = startPosition.rotation;

            SetActive(true);
            UniTaskVoid bulletTimer = BulletLiveTimer();
        }

        private async UniTaskVoid BulletLiveTimer()
        {
            await UniTask.Delay(_timeToLive, cancellationToken: _cts.Token);
            SetActive(false);
        }

        public void StopBullet()
        {
            CleanCTS();
            SetActive(false);
        }

        private void CleanCTS()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        private void Move()
        {
            _rigidbody.AddForce(transform.up * _bulletMovementSpeed, ForceMode2D.Force);
        }

        private void OnDestroy()
        {
            CleanCTS();
        }
    }
}