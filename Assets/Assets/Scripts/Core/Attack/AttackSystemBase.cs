using System;
using UniRx;

namespace Core
{
    public abstract class AttackSystemBase : IDisposable
    {
        protected IAttacker Attacker;
        
        private AnimationController _animationController;

        protected readonly CompositeDisposable Disposables = new();

        public void SetData(IAttacker attacker, AnimationController animationController)
        {
            Attacker = attacker;
            _animationController = animationController;
        }

        protected virtual void TryAttack()
        {
            if(Attacker == null)
                return;
            
            if (!Attacker.CanAttack())
                return;

            PerformAttack();
        }

        protected virtual void PerformAttack()
        {
            _animationController?.SetAttackStatus(true);
        }

        protected virtual void OnAttackPerformed()
        {
            Attacker.MarkAttack();
            _animationController.SetAttackStatus(false);
        }

        public virtual void Dispose()
        {
            Disposables.Dispose();
        }
    }
}