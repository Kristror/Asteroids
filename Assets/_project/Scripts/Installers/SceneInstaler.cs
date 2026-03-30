using Enemies;
using Enemies.Spawners;
using Player;
using UI;
using UnityEngine;
using Utilites;
using Zenject;
using Zenject.Asteroids;

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
                .Bind<BorderController>()
                .AsSingle();

            Container
                .Bind<ScoreController>()
                .AsSingle();

            Container.
                Bind<TimeController>()
                .AsSingle()
                .NonLazy();

            Container.
                Bind<SceneController>()
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
        }

        private void BindEnemies()
        {
            Container.Bind<EnemyFactory>().AsSingle();

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
               .BindFactory<UIplayerStats, UIFactory>()
               .FromComponentInNewPrefab(Resources.Load<GameObject>("GameUI"));

            Container
                .Bind<UIController>()
                .AsSingle();
        }
    }
}