using UnityEngine;
using System;

namespace TZ_Eisvil
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private EEnemyType _enemyType;

        public event Action<EnemyController> OnDeath;
        public EEnemyType EnemyType => _enemyType;

        public void Init(EEnemyType enemyType)
        {
            _enemyType = enemyType;
            _spriteRenderer.color = GetColor(enemyType);
        }

        public void Death()
        {
            Debug.Log("Death " + gameObject.name);
            OnDeath?.Invoke(this); // Уведомляем подписчиков
            Destroy(gameObject);
        }

        private Color GetColor(EEnemyType type)
        {
            switch (type)
            {
                case EEnemyType.Type1:
                    return Color.red;
                case EEnemyType.Type2:
                    return Color.blue;
                case EEnemyType.Type3:
                    return Color.green;

                default:
                    return Color.white;
            }
        }
        
        private void OnMouseDown() => Death();
    }
}