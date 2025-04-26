using UnityEngine;

namespace Core
{
    public class CharacterAnimatorView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Animator Animator => _animator;
    }
}