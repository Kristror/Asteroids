using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Utilities.AssetLoading
{
    public class AssetsProvider : IDisposable
    {
        public GameObject PlayerObject;
        public GameObject BulletObject;
        public GameObject AsteroidObject;
        public GameObject SmallAsteroidObject;
        public GameObject UFOObject;
        public GameObject AsteroidSpawnerObject;
        public GameObject UFOSpawnerObject;
        public GameObject DeathUIObject;
        public GameObject PlayerReviveUIObject;
        public GameObject PlayerStatsUIObject;
        public GameObject MainMenuUIObject;

        public bool IsMainMenuAssetsLoaded = false;
        public bool IsGameAssetsLoaded = false;

        private IAssetLoader _assetLoader;
        private CancellationTokenSource _cts;

        public AssetsProvider(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        
        public async UniTask LoadMainMenuAssets()
        {
            _cts = new CancellationTokenSource();

            await LoadMainMenuUI().AttachExternalCancellation(_cts.Token);
            IsMainMenuAssetsLoaded = true;
        }

        public async UniTask LoadGameAssets() 
        {
            _cts = new CancellationTokenSource();

            await UniTask.WhenAll(
                LoadPlayer(), LoadBullet(), LoadAsteroid(), LoadSmallAsteroid(),
                LoadUFO(), LoadAsteroidSpawner(), LoadUFOSpawner(), LoadDeathUI(),
                LoadPlayerReviveUI(), LoadPlayerStatsUI()).AttachExternalCancellation(_cts.Token);
            IsGameAssetsLoaded = true;
        }

        private async UniTask LoadMainMenuUI()
        {
            MainMenuUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.MAIN_MENU_UI);
        }

        private async UniTask LoadPlayer()
        {
            PlayerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.PLAYER);            
        }

        private async UniTask LoadBullet()
        {
            BulletObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.BULLET);
        }

        private async UniTask LoadAsteroid()
        {
            AsteroidObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.ASTEROID);
        }

        private async UniTask LoadSmallAsteroid()
        {
            SmallAsteroidObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.SMALL_ASTEROID);
        }

        private async UniTask LoadUFO()
        {
            UFOObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.UFO);
        }

        private async UniTask LoadAsteroidSpawner()
        {
            AsteroidSpawnerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.ASTEROID_SPAWNER);
        }

        private async UniTask LoadUFOSpawner()
        {
            UFOSpawnerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.UFO_SPAWNER);
        }

        private async UniTask LoadDeathUI()
        {
            DeathUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.DEATH_UI);
        }

        private async UniTask LoadPlayerReviveUI()
        {
            PlayerReviveUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.PLAYER_REVIVE_UI);
        }

        private async UniTask LoadPlayerStatsUI()
        {
            PlayerStatsUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.PLAYER_STATS_UI);
        }

        public void Dispose()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }
    }
}