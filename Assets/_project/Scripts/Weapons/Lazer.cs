using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Weapons
{
    public class Lazer : MonoBehaviour
    {
        private int _lazerDuration;
        private CancellationTokenSource _cts;

        public void SetLazerDuration(int lazerDuration)
        {
            _cts = new CancellationTokenSource();
            _lazerDuration = lazerDuration;
        }

        public void Shoot()
        {
            gameObject.SetActive(true);

            UniTaskVoid waitForLazer = LazerActivity();
        }

        private async UniTaskVoid LazerActivity()
        {
            await UniTask.Delay(_lazerDuration, cancellationToken: _cts.Token);
            Deactivate();
        }

        private void Deactivate()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
            gameObject.SetActive(false);
        }
    }
}