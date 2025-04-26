using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private UniversalRigidbody _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        
        public UniversalRigidbody Rigidbody => _rigidbody;
        public Transform Transform => _transform;
        public Animator Animator => _animator;
    }
}