using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Utilities.AssetLoading
{
    public class AssetsProvider 
    {
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

        public bool isMainMenuAssetsLoaded = false;
        public bool isGameAssetsLoaded = false;


        public AssetsProvider(IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        
        public async UniTask LoadMainMenuAssets()
        {
            await LoadMainMenuUI();
            isMainMenuAssetsLoaded = true;
        }

        public async UniTask LoadGameAssets() 
        {
            await UniTask.WhenAll(
                LoadPLayer(), LoadBullet(), LoadAsteroid(), LoadSmallAsteroid(),
                LoadUFO(), LoadAsteroidSpawner(), LoadUFOSpawner(), LoadDeathUI(), LoadPlayerStatsUI());
            isGameAssetsLoaded = true;
        }

        private async UniTask LoadMainMenuUI()
        {
            MainMenuUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.MainMenuUI);
        }

        private async UniTask LoadPLayer()
        {
            PlayerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.Player);            
        }

        private async UniTask LoadBullet()
        {
            BulletObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.Bullet);
        }

        private async UniTask LoadAsteroid()
        {
            AsteroidObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.Asteroid);
        }

        private async UniTask LoadSmallAsteroid()
        {
            SmallAsteroidObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.SmallAsteroid);
        }

        private async UniTask LoadUFO()
        {
            UFOObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.UFO);
        }

        private async UniTask LoadAsteroidSpawner()
        {
            AsteroidSpawnerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.AsteroidSpawner);
        }

        private async UniTask LoadUFOSpawner()
        {
            UFOSpawnerObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.UFOSpawner);
        }

        private async UniTask LoadDeathUI()
        {
            DeathUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.DeathUI);
        }

        private async UniTask LoadPlayerStatsUI()
        {
            PlayerStatsUIObject = await _assetLoader.LoadObjectByName(AssetsLocalPath.PlayerStatsUI);
        }
    }
}