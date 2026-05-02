using Enemies;
using Enemies.Spawners;
using Player;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilites;
using Weapons;
using Zenject;

namespace Instalers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayer();
            BindUtilities();
            BindEnemies();
            BindUI();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle();

            Container.BindFactory<PlayerShip, PlayerShipFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("Player"));

            Container.BindInterfacesAndSelfTo<PlayerObject>().AsSingle();

            Container.BindFactory<BulletCollision, BulletFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("Bullet"));
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

        private void BindEnemies()
        {
            Container.BindFactory<Asteroid, AsteroidFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("Asteroid"));            
            Container.BindFactory<SmallAsteroid, SmallAsteroidFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("SmallAsteroid"));            
            Container.BindFactory<UFO, UFOFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("UFO"));

            Container.Bind<EnemyFactory>().AsSingle();

            Container.BindFactory<AsteroidSpawner, AsteroidSpawnerFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("AsteroidSpawner"));               
            Container.BindFactory<UFOSpawner, UFOSpawnerFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("UFOSpawner"));

            Container.BindInterfacesAndSelfTo<EnemiesSpawnerFactoryRunner>().AsSingle().NonLazy();
        }

        private void BindUI()
        {
            Container.BindFactory<PlayerStatsUIView, PlayerStatsUIViewFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("PlayerStatsUI"));            
            Container.BindFactory<DeathUIView, DeathUIViewFactory>().FromComponentInNewPrefab(Resources.Load<GameObject>("DeathUI"));

            Container.Bind<DeathUIModel>().AsSingle();
            Container.Bind<PlayerStatsUIModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<DeathUIPresenter>().AsSingle();            
            Container.BindInterfacesAndSelfTo<PlayerStatsUIPresenter>().AsSingle();

            Container.BindInterfacesAndSelfTo<UIPresenterInitializer>().AsSingle().NonLazy();
        }
    }
}