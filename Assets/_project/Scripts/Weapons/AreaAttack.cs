using Configs;
using Cysharp.Threading.Tasks;
using Player;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class AreaAttack : MonoBehaviour, ISecondaryWeapon
    {
        private int _activeTime;
        private float _size;

        private PlayerReviveController _playerReviveController;
        private ConfigsController _configController;
        private CancellationTokenSource _cts;

        [Inject]
        public void Construct(PlayerReviveController playerReviveController, ConfigsController configsController)
        {
            _playerReviveController = playerReviveController;
            _configController = configsController;
        }

        public void Start()
        {
            _activeTime = _configController.GetAreaActiveTime();
            _size = _configController.GetAreaSize();

            _playerReviveController.ReviveAction += Attack;
            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            _playerReviveController.ReviveAction -= Attack;
            _cts?.Cancel();
            _cts?.Dispose();
        }

        private void Attack()
        {
            transform.localScale = new Vector3(_size, _size, 1);
            gameObject.SetActive(true);
            _cts = new CancellationTokenSource();
            UniTaskVoid deactivateAttack = Deactivate();
        }

        private async UniTaskVoid Deactivate()
        {
            await UniTask.Delay(_activeTime, cancellationToken: _cts.Token);
            gameObject.SetActive(false);
        }
    }
}