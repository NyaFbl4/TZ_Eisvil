using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TZ_Eisvil
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Transform _worldTransform;

        [SerializeField] private int _enemyTypeCounts;

        private EnemyGlobalTracker _globalTracker;
        
        private Camera _camera;
        private float _minBorderOffset = 0f;
        private float _maxBorderOffset = 0f;

        private List<IEnemyController> _activeEnemyPool;

        [Inject]
        public void Construct(EnemyGlobalTracker globalTracker, EnemyPool enemyPool)
        {
            _camera = Camera.main;
            _globalTracker = globalTracker;
            _enemyPool = enemyPool;

            foreach (EEnemyType type in Enum.GetValues(typeof(EEnemyType)))
            {
                for (int i = 0; i < _enemyTypeCounts; i++)
                {
                    SpawnEnemy(type);
                }
            }
        }

        private void SpawnEnemy(EEnemyType enemyType)
        {
            var enemy = _enemyPool.GetEnemy();
            
            enemy.transform.parent = _worldTransform.parent;
            enemy.transform.position = GetRandomPositionInViewport();

            enemy.Init(enemyType);
            _globalTracker.RegisterEnemy(enemy);
        }

        private Vector3 GetRandomPositionInViewport()
        {
            return _camera.ViewportToWorldPoint(new Vector3(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                10f));
        }
        
        private EEnemyType GetRandomEnemyType()
        {
            var values = Enum.GetValues(typeof(EEnemyType));
            var randomIndex = Random.Range(0, values.Length);

            return (EEnemyType) values.GetValue(randomIndex);
        }
    }
}