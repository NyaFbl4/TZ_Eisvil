using UnityEngine;

namespace TZ_Eisvil
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyController _prefab;
        [SerializeField] private int _initialCount;
        
        public EnemyController EnemyPrefab => _prefab;
        public int InitialCount => _initialCount;

    }
}