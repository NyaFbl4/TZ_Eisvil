using System.Collections.Generic;
using UnityEngine;

namespace TZ_Eisvil
{
    public class EnemyPool
    {
        private EnemyController _prefabEnemy;
        private Transform _parent;
        private int _countEnemy;
        private EnemyFactory _enemyFactory;

        private Queue<EnemyController> _enemyPool = new();

        public EnemyPool(EnemyController prefabEnemy, Transform parent, int countEnemy, EnemyFactory enemyFactory)
        {
            _prefabEnemy = prefabEnemy;
            _parent = parent;
            _countEnemy = countEnemy;
            _enemyFactory = enemyFactory;

            Init(_countEnemy);
        }

        private void Start()
        {
            //Init(_countEnemy);
        }
        
        public void Init(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                _enemyPool.Enqueue(CreateNewEnemy());
            }
        }

        
        public EnemyController GetEnemy()
        {
            if (_enemyPool.Count == 0)
            {
                return CreateNewEnemy();
            }

            var enemy = _enemyPool.Dequeue();
            return enemy;
        }

        public void ReturnEnemy(EnemyController enemy)
        {
            _enemyPool.Enqueue(enemy);
        }
        
        
        private EnemyController CreateNewEnemy()
        {
            //var enemy = Instantiate(_prefabEnemy, Vector3.zero, Quaternion.identity, _parent);
            var enemy = _enemyFactory.Create();

            return enemy;
        }
        
    }
}