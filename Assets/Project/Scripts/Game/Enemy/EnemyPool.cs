using System.Collections.Generic;
using UnityEngine;

namespace TZ_Eisvil
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private EnemyController _prefabEnemy;
        [SerializeField] private Transform _parent;

        private Queue<EnemyController> _enemyPool = new();

        private void Start()
        {
            Init(20);
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
            var enemy = Instantiate(_prefabEnemy, 
                Vector3.zero, Quaternion.identity, _parent);

            return enemy;
        }
    }
}