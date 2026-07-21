using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AssetLoading
{
    public class AssetsProvider 
    {
        private AssetsConstants _assetsConstants;
        private IAssetLoader _assetLoader;

        public GameObject MainMenuUIObject;

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
            _assetsConstants = new AssetsConstants();
        }
        
        public async UniTask LoadMainMenuAssets()
        {
            await LoadMainMenuUI();
        }

        public async UniTask LoadGameAssets() 
        {
            await UniTask.WhenAll(
                LoadPLayer(), LoadBullet(), LoadAsteroid(), LoadSmallAsteroid(),
                LoadUFO(), LoadAsteroidSpawner(), LoadUFOSpawner(), LoadDeathUI(), LoadPlayerStatsUI());
        }

        private async UniTask LoadMainMenuUI()
        {
            MainMenuUIObject = await _assetLoader.LoadObjectByName(_assetsConstants.MainMenuUI);
        }

        private async UniTask LoadPLayer()
        {
            PlayerObject = await _assetLoader.LoadObjectByName(_assetsConstants.Player);            
        }

        private async UniTask LoadBullet()
        {
            BulletObject = await _assetLoader.LoadObjectByName(_assetsConstants.Bullet);
        }

        private async UniTask LoadAsteroid()
        {
            AsteroidObject = await _assetLoader.LoadObjectByName(_assetsConstants.Asteroid);
        }

        private async UniTask LoadSmallAsteroid()
        {
            SmallAsteroidObject = await _assetLoader.LoadObjectByName(_assetsConstants.SmallAsteroid);
        }

        private async UniTask LoadUFO()
        {
            UFOObject = await _assetLoader.LoadObjectByName(_assetsConstants.UFO);
        }

        private async UniTask LoadAsteroidSpawner()
        {
            AsteroidSpawnerObject = await _assetLoader.LoadObjectByName(_assetsConstants.AsteroidSpawner);
        }

        private async UniTask LoadUFOSpawner()
        {
            UFOSpawnerObject = await _assetLoader.LoadObjectByName(_assetsConstants.UFOSpawner);
        }

        private async UniTask LoadDeathUI()
        {
            DeathUIObject = await _assetLoader.LoadObjectByName(_assetsConstants.DeathUI);
        }

        private async UniTask LoadPlayerStatsUI()
        {
            PlayerStatsUIObject = await _assetLoader.LoadObjectByName(_assetsConstants.PlayerStatsUI);
        }
    }
}