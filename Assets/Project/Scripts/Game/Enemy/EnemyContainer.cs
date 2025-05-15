using UnityEngine;

namespace TZ_Eisvil
{
    public class EnemyContainer : MonoBehaviour
    {
        [Header("Трасформы спавна для Bullets")]
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _worldTransform;
        
        public Transform Container => _container;
        public Transform WorldTransform => _worldTransform;
 
    }
}