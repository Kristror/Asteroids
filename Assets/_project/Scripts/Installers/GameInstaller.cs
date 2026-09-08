using Ads;
using Enemies;
using Enemies.Spawners;
using Player;
using PlayerAnalytics;
using Saving;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;
using Utilities.AssetLoading;
using Weapons;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        private AssetsProvider _assetsProvider;

        [Inject]
        public void Construct(AssetsProvider assetsProvider)
        {
            _assetsProvider = assetsProvider;
        }

        public override void InstallBindings()
        {
            BindPlayer();
            BindUtilities();
            BindSaving();
            BindAnalytics();
            BindEnemies();
            BindUI();
            BindAds();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle();
            Container.BindFactory<PlayerShip, PlayerShipFactory>().FromComponentInNewPrefab(_assetsProvider.PlayerObject);
            Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();
            Container.BindExecutionOrder<PlayerProvider>(-1);
            Container.BindInterfacesAndSelfTo<PlayerReviveController>().AsSingle();

            Container.BindFactory<BulletMovement, BulletFactory>().FromComponentInNewPrefab(_assetsProvider.BulletObject);
            Container.Bind<BulletPool>().AsSingle();
        }

        private void BindUtilities()
        {
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
            Container.Bind<Keyboard>().FromInstance(Keyboard.current).AsSingle();
            Container.Bind<Mouse>().FromInstance(Mouse.current).AsSingle();

            Container.BindInterfacesAndSelfTo<BorderController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreController>().AsSingle();

            Container.BindInterfacesAndSelfTo<TimeController>().AsSingle();
        }

        private void BindSaving()
        {
            Container.Bind<IPlayerSaveLoad>().To<PlayerPrefsSaving>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerSaveController>().AsSingle();
        }

        private void BindAnalytics()
        {
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
            Container.BindFactory<PlayerReviveView, PlayerReviveViewFactory>().FromComponentInNewPrefab(_assetsProvider.PlayerReviveUIObject);

            Container.BindInterfacesAndSelfTo<DeathUIModel>().AsSingle();
            Container.Bind<PlayerStatsUIModel>().AsSingle();
            Container.Bind<PlayerReviveModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<DeathUIPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStatsUIPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerRevivePresenter>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameUIPresenterInitializer>().AsSingle();
            Container.BindExecutionOrder<GameUIPresenterInitializer>(-1);
        }

        private void BindAds()
        {
            Container.BindInterfacesAndSelfTo<UnityLevelPlayAds>().AsSingle();
            Container.BindInterfacesAndSelfTo<AdsController>().AsSingle();
        }
    }
}