using UnityEngine;

namespace Core
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public Animator Animator => _animator;
    }
}