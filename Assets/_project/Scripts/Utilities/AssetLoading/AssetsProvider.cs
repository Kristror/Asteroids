using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AssetLoading
{
    public class AssetsProvider 
    {
        private AssetsConstants _assetsConstants = new AssetsConstants();
        private IAssetLoader _assetLoader;

        public GameObject PlayerObject;
        public GameObject BulletObject;
        public GameObject AsteroidObject;
        public GameObject SmallAsteroidObject;
        public GameObject UFOObject;
        public GameObject AsteroidSpawnerObject;
        public GameObject UFOSpawnerObject;
        public GameObject DeathUIObject;
        public GameObject PlayerStatsUIObject;

        public AssetsProvider(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public async void LoadAssets() 
        {
            await UniTask.WhenAll(
                LoadPLayer(), LoadBullet(), LoadAsteroid(), LoadSmallAsteroid(),
                LoadUFO(), LoadAsteroidSpawner(), LoadUFOSpawner(), LoadDeathUI(), LoadPlayerStatsUI());
        }

        private async UniTask LoadPLayer()
        {
            PlayerObject = await _assetLoader.LoadObjectByName(AssetsConstants.Player);            
        }

        private async UniTask LoadBullet()
        {
            BulletObject = await _assetLoader.LoadObjectByName(AssetsConstants.Bullet);
        }

        private async UniTask LoadAsteroid()
        {
            AsteroidObject = await _assetLoader.LoadObjectByName(AssetsConstants.Asteroid);
        }

        private async UniTask LoadSmallAsteroid()
        {
            SmallAsteroidObject = await _assetLoader.LoadObjectByName(AssetsConstants.SmallAsteroid);
        }

        private async UniTask LoadUFO()
        {
            UFOObject = await _assetLoader.LoadObjectByName(AssetsConstants.UFO);
        }

        private async UniTask LoadAsteroidSpawner()
        {
            AsteroidSpawnerObject = await _assetLoader.LoadObjectByName(AssetsConstants.AsteroidSpawner);
        }

        private async UniTask LoadUFOSpawner()
        {
            UFOSpawnerObject = await _assetLoader.LoadObjectByName(AssetsConstants.UFOSpawner);
        }

        private async UniTask LoadDeathUI()
        {
            DeathUIObject = await _assetLoader.LoadObjectByName(AssetsConstants.DeathUI);
        }

        private async UniTask LoadPlayerStatsUI()
        {
            PlayerStatsUIObject = await _assetLoader.LoadObjectByName(AssetsConstants.PlayerStatsUI);
        }
    }
}