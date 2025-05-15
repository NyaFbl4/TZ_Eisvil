using UnityEngine;
using Zenject;

namespace TZ_Eisvil
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyController _enemyPrefab;
        [SerializeField] private EnemyContainer _enemyContainer;
        [SerializeField] private EnemyConfig _enemyConfig;
        public override void InstallBindings()
        {
            Container
                .Bind<EnemyContainer>()
                .FromInstance(_enemyContainer)
                .AsSingle();
        
            Container
                .Bind<EnemyConfig>()
                .FromInstance(_enemyConfig)
                .AsSingle();

            Container
                .Bind<EnemyPool>()
                .AsSingle()
                .WithArguments(_enemyPrefab, 
                               _enemyContainer.Container, 
                               _enemyConfig.InitialCount);

            Container
                .BindFactory<EnemyController, EnemyFactory>()
                .FromComponentInNewPrefab(_enemyPrefab)
                .UnderTransform(_enemyContainer.Container);

            Container
                .Bind<EnemyGlobalTracker>()
                .AsSingle();

            Container
                .Bind<EnemySpawner>()
                .AsSingle()
                .WithArguments(_enemyContainer.WorldTransform, _enemyConfig.EnemyTypeCounts)
                .NonLazy();
        }
    }
}