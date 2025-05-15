using UnityEngine;

namespace TZ_Eisvil
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyController _prefab;
        [SerializeField] private int _initialCount;
        [SerializeField] private int _enemyTypeCounts;
        
        public EnemyController EnemyPrefab => _prefab;
        public int InitialCount => _initialCount;
        public int EnemyTypeCounts => _enemyTypeCounts;
    }
}