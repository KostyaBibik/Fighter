using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Core
{
    public class EnemyAttackSystem : AttackSystemBase
    {
        private CancellationToken _cancellationToken;
        
        private readonly IAttackable _player;
        private readonly float _attackCooldown;
        private readonly CancellationTokenSource _cts;
        private readonly CompositeDisposable _disposables = new();

        public EnemyAttackSystem(IAttackable player, HealthModel selfHealth, float attackCooldown)
        {
            _player = player;
            _attackCooldown = attackCooldown;
            _cts = new CancellationTokenSource();
            
            SubscribeToDeathEvents(selfHealth);
            RunAttackLoop().Forget();
        }

        private void SubscribeToDeathEvents(HealthModel selfHealth)
        {
            _player
                .Health
                .OnDied
                .Subscribe(_ => CancelAttackLoop())
                .AddTo(_disposables);
            
            selfHealth
                .OnDied
                .Subscribe(_ => CancelAttackLoop())
                .AddTo(_disposables);
        }
        
        private void CancelAttackLoop()
        {
            if (_cts?.IsCancellationRequested != false) 
                return;
            
            _cts.Cancel();
        }
        
        private async UniTaskVoid RunAttackLoop()
        {
            await UniTask.Yield(); 
            
            _cancellationToken = _cts.Token;

            while (!_cancellationToken.IsCancellationRequested)
            {
                if(_player == null)
                    return;
                
                var distance = Vector3.Distance(Attacker.Position, _player.Position);
                
                if (distance <= Attacker.AttackRange && Attacker.CanAttack())
                {
                    PerformAttack();
                    
                    await UniTask.Delay(TimeSpan.FromSeconds(_attackCooldown), cancellationToken: _cancellationToken);

                    if (_cancellationToken.IsCancellationRequested)
                        break;

                    OnAttackPerformed();
                }
                
                await UniTask.Yield(); 
            }
        }

        protected override void OnAttackPerformed()
        {
            if (Vector3.Distance(Attacker.Position, _player.Position) <= Attacker.AttackRange)
            {
                _player.Health.TakeDamage(Attacker.Damage);
            }

            base.OnAttackPerformed();
        }

        public new void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}