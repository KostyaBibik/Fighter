
using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace Core
{
    public sealed class PlayerAttackSystem : AttackSystemBase, IInitializable
    {
        private IInputService _inputService;
        private EnemyRegistry _enemyRegistry;
        private float _attackCooldown;

        [Inject]
        public void Construct(IInputService inputService, EnemyRegistry enemyRegistry)
        {
            _inputService = inputService;
            _enemyRegistry = enemyRegistry;
        }
        
        public void Initialize()
        {
            _inputService
                .AttackPreformed
                .Subscribe(_ => TryAttack())
                .AddTo(Disposables);
        }

        public void SetAttackCooldown(float cooldown) =>
            _attackCooldown = cooldown;
        
        protected override void PerformAttack()
        {
            base.PerformAttack();

            RunAttack().Forget();
        }
        
        private async UniTaskVoid RunAttack()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_attackCooldown));

            if (Attacker == null) 
                return;

            var enemies = _enemyRegistry
                .GetEnemiesInRange(Attacker.Position, Attacker.AttackRange)
                .ToList();

            foreach (var enemy in enemies)
            {
                enemy.Health.TakeDamage(Attacker.Damage);
            }
            
            OnAttackPerformed();
        }

        protected override void OnAttackPerformed()
        {
            base.OnAttackPerformed();
        }
    }
}