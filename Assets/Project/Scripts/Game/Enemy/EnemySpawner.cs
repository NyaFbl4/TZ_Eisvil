using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TZ_Eisvil
{
    public class EnemySpawner
    {
        private readonly EnemyPool _enemyPool;
        private readonly Transform _worldTransform;

        private readonly int _enemyTypeCounts;

        private readonly EnemyGlobalTracker _globalTracker;
        
        private readonly Camera _camera;
        private readonly float _minBorderOffset = 0f;
        private readonly float _maxBorderOffset = 0f;

        private readonly List<IEnemyController> _activeEnemyPool;
        
        public EnemySpawner(EnemyGlobalTracker globalTracker, EnemyPool enemyPool, 
            Transform worldTransform, int EnemyTypeCounts)
        {
            Debug.Log("EnemySpawner");
            
            _camera = Camera.main;
            _globalTracker = globalTracker;
            _enemyPool = enemyPool;
            _worldTransform = worldTransform;
            _enemyTypeCounts = EnemyTypeCounts;

            Debug.Log(_enemyTypeCounts);
            
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
            Debug.Log("SpawnEnemy");
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