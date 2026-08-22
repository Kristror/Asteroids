using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Weapons
{
    public class Laser : MonoBehaviour, ISecondaryWeapon
    {
        private int _laserDuration;
        private CancellationTokenSource _cts;

        public void SetLaserDuration(int laserDuration)
        {            
            _laserDuration = laserDuration;
        }

        public void Shoot()
        {
            CleanCTS();
            _cts = new CancellationTokenSource();

            gameObject.SetActive(true);

            UniTaskVoid waitForLaser = LaserActivity();
        }

        private async UniTaskVoid LaserActivity()
        {
            await UniTask.Delay(_laserDuration, cancellationToken: _cts.Token);
            Deactivate();
        }

        private void Deactivate()
        {
            CleanCTS();
            gameObject.SetActive(false);
        }

        private void CleanCTS()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }

        private void OnDestroy()
        {
            CleanCTS();
        }
    }
}