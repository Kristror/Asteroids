using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        private const int TIME_TO_LIVE = 2000;

        [SerializeField, Min(0)] private float _bulletMovementSpeed;


        private Rigidbody2D _rigidbody;

        private CancellationTokenSource _cts;

        private void Awake()
        {
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
            await UniTask.Delay(TIME_TO_LIVE, cancellationToken: _cts.Token);
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