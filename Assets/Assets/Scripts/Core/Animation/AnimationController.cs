using UnityEngine;

namespace Core
{
    public class AnimationController : IAnimationController
    {
        private readonly Animator _animator;
        private readonly int AttackStateHash = Animator.StringToHash("Attack");
        private readonly int MovementStateHash = Animator.StringToHash("Movement");

        public AnimationController(Animator animator) =>
            _animator = animator;

        public void SetAttackStatus(bool flag) =>
            _animator?.SetBool(AttackStateHash, flag);
        
        public void SetMovement(float velocityMagnitude) =>
            _animator?.SetFloat(MovementStateHash, velocityMagnitude);
    }
}