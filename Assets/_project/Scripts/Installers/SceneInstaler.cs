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
            BindUnitlities();
            BindPlayer();
            BindEnemies();
            BindUI();
        }   

        private void BindUnitlities()
        {
            Container
                .Bind<Camera>()
                .FromInstance(Camera.main)
                .AsSingle();
            
            Container
                .Bind<Keyboard>()
                .FromInstance(Keyboard.current)
                .AsSingle();
            
            Container
                .Bind<Mouse>()
                .FromInstance(Mouse.current)
                .AsSingle();


            Container
                .Bind<BorderController>()
                .AsSingle();

            Container
                .Bind<ScoreController>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TimeController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SceneController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayer()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerInputController>()
                .AsSingle();

            Container
                .BindFactory<PlayerMovement, PlayerFactory>()
                .FromComponentInNewPrefab(Resources.Load<GameObject>("Player"));

            Container
                .Bind<PlayerController>()
                .AsSingle();

            Container
                .BindFactory<BulletCollision, BulletFactory>()
                .FromComponentInNewPrefab(Resources.Load<GameObject>("Bullet"));
        }

        private void BindEnemies()
        {
            Container
                .BindFactory<AsteroidMovement, AsteroidFactory>()
                .FromComponentInNewPrefab(Resources.Load<GameObject>("Asteroid"));
            
            Container
                .BindFactory<SmallAsteroid, SmallAsteroidFactory>()
                .FromComponentInNewPrefab(Resources.Load<GameObject>("SmallAsteroid"));
            
            Container
                .BindFactory<UFOMovement, UFOFactory>()
                .FromComponentInNewPrefab(Resources.Load<GameObject>("UFO"));

            Container
                .Bind<EnemyFactory>()
                .AsSingle();

            Container
               .BindFactory<AsteroidSpawnController, EnemiesControllerFactory>()
               .FromComponentInNewPrefab(Resources.Load<GameObject>("EnemySpawner"));

            Container
                .Bind<EnemiesController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindUI()
        {
            Container
               .BindFactory<PlayerStatsUIView, UIFactory>()
               .FromComponentInNewPrefab(Resources.Load<GameObject>("GameUI"));

            Container
                .Bind<DeathUIModel>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<DeathUIPresenter>()
                .AsSingle();

            Container
                .Bind<PlayerStatsUIModel>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PlayerStatsUIPresenter>()
                .AsSingle();

            Container
                .Bind<UIManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}