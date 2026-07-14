using AssetLoading;
using Enemies;
using Enemies.Spawners;
using Player;
using PlayerAnalytics;
using Saving;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilites;
using Weapons;
using Zenject;
using Cysharp.Threading.Tasks;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        private AssetsProvider _assetsProvider;

        public override void InstallBindings()
        {
            LoadObjects();
            WaitForLoadThenBind();
        }

        private void LoadObjects()
        {
            LoacalAddressablesLoader loader = new();
            _assetsProvider = new(loader);
            _assetsProvider.LoadAssets();
        }

        private async void WaitForLoadThenBind()
        {
            while (true)
            {
                if (_assetsProvider.PlayerObject != null) break;
                await UniTask.Delay(1);
            }

            BindPlayer();
            BindUtilities();
            BindSaving();
            BindAnalytics();
            BindEnemies();
            BindUI();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle();
            Container.BindFactory<PlayerShip, PlayerShipFactory>().FromComponentInNewPrefab(_assetsProvider.PlayerObject);
            Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();

            Container.BindFactory<BulletMovement, BulletFactory>().FromComponentInNewPrefab(_assetsProvider.BulletObject);
            Container.Bind<BulletPool>().AsSingle();
        } 

        private void BindUtilities()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();            
            Container.Bind<Keyboard>().FromInstance(Keyboard.current).AsSingle();            
            Container.Bind<Mouse>().FromInstance(Mouse.current).AsSingle();

            Container.Bind<BorderController>().AsSingle();
            Container.Bind<ScoreController>().AsSingle();

            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneController>().AsSingle();
        }

        private void BindSaving()
        {
            Container.Bind<IPlayerSaveLoad>().To<PlayerPrefsSaving>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerSaveController>().AsSingle();
        }
        
        private void BindAnalytics()
        {
            Container.Bind<IAnalytics>().To<AnalyticsWthFirebase>().AsSingle();

            Container.BindInterfacesAndSelfTo<AnalyticsController>().AsSingle();
            Container.Bind<PlayerStatisticsController>().AsSingle();
        }

        private void BindEnemies()
        {
            Container.BindFactory<Asteroid, AsteroidFactory>().FromComponentInNewPrefab(_assetsProvider.AsteroidObject);            
            Container.BindFactory<SmallAsteroid, SmallAsteroidFactory>().FromComponentInNewPrefab(_assetsProvider.SmallAsteroidObject);            
            Container.BindFactory<UFO, UFOFactory>().FromComponentInNewPrefab(_assetsProvider.UFOObject);

            Container.Bind<EnemyFactory>().AsSingle();

            Container.BindFactory<AsteroidSpawner, AsteroidSpawnerFactory>().FromComponentInNewPrefab(_assetsProvider.AsteroidSpawnerObject);               
            Container.BindFactory<UFOSpawner, UFOSpawnerFactory>().FromComponentInNewPrefab(_assetsProvider.UFOSpawnerObject);

            Container.BindInterfacesAndSelfTo<EnemiesSpawnerFactoryRunner>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindFactory<PlayerStatsUIView, PlayerStatsUIViewFactory>().FromComponentInNewPrefab(_assetsProvider.PlayerStatsUIObject);            
            Container.BindFactory<DeathUIView, DeathUIViewFactory>().FromComponentInNewPrefab(_assetsProvider.DeathUIObject);

            Container.Bind<DeathUIModel>().AsSingle();
            Container.Bind<PlayerStatsUIModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<DeathUIPresenter>().AsSingle();            
            Container.BindInterfacesAndSelfTo<PlayerStatsUIPresenter>().AsSingle();

            Container.BindInterfacesAndSelfTo<UIPresenterInitializer>().AsSingle(); 
        }
    }
}