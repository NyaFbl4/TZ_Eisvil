using System;
using System.Collections.Generic;
using UnityEngine;

namespace TZ_Eisvil
{
    public class EnemyGlobalTracker
    {
        private readonly List<EnemyController> _activeEnemyPool = new();
        private readonly Dictionary<EEnemyType, int> _deathStats = new();

        public EnemyGlobalTracker()
        {
            Debug.Log("Create EnemyGlobalTracker");
        }

        public event Action<EnemyController> OnDeathEnemy;
        
        
        
        public void RegisterEnemy(EnemyController enemy)
        { 
            enemy.OnDeath += HandleDeath;
            _activeEnemyPool.Add(enemy);
        }
        
        private void HandleDeath(EnemyController enemy)
        {
            // Обновляем статистику
            var type = enemy.EnemyType;
            Debug.Log("Death enemy " + type.ToString());
            _deathStats[type] = _deathStats.TryGetValue(type, out var count) ? count + 1 : 1;
        
            // Чистим ссылки
            _activeEnemyPool.Remove(enemy);
            enemy.OnDeath -= HandleDeath;
        
            // Уведомляем подписчиков
            OnDeathEnemy?.Invoke(enemy);
        }
    }
}