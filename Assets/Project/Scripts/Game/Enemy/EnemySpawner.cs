using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TZ_Eisvil
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField] private EnemyGlobalTracker _globalTracker;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private List<Color> _colors;
        
        [SerializeField] private Camera _camera;
        private float _minBorderOffset = 0f;
        private float _maxBorderOffset = 0f;

        private List<IEnemyController> _activeEnemyPool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyPool.GetEnemy();
            
            enemy.transform.parent = _worldTransform.parent;
            enemy.transform.position = GetRandomPositionInViewport();

            enemy.Init(GetRandomEnemyType());
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