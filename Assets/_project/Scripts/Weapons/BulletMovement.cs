using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _bulletMovementSpeed;

        private const int _timeToLive = 2000;

        private Rigidbody2D _rigidBody;

        private CancellationTokenSource _cts;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        public void StartMovementFromPoint(Transform startPosition)
        {
            transform.position = startPosition.position;
            transform.rotation = startPosition.rotation;

            SetActive(true);
            UniTaskVoid waitForLazer = StopBullet();
        }

        private async UniTaskVoid StopBullet()
        {
            _cts = new CancellationTokenSource();
            await UniTask.Delay(_timeToLive, cancellationToken: _cts.Token);
            SetActive(false);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        private void Move()
        {
            _rigidBody.AddForce(transform.up * _bulletMovementSpeed, ForceMode2D.Force);
        }

        private void OnDestroy()
        {
            _cts?.Dispose();
        }
    }
}