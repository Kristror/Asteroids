using Cysharp.Threading.Tasks;
using Player;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class AreaAttack : MonoBehaviour, ISecondaryWeapon
    {
        [SerializeField] private int _activeTime = 1000;
        private float _size = 6;

        private PlayerReviveController _playerReviveController;
        private CancellationTokenSource _cts;

        [Inject]
        public void Construct(PlayerReviveController playerReviveController)
        {
            _playerReviveController = playerReviveController;
        }

        public void Start()
        {
            _playerReviveController.SubscribeToReviveAction(Attack);
            gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _playerReviveController.UnsubscribeFromReviveAction(Attack);
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