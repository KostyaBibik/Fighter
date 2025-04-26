using System;
using UniRx;
using UnityEngine;

namespace Core
{
    public class HealthModel
    {
        public ReactiveProperty<int> CurrentHP { get; private set; }
        public int MaxHP { get; private set; }
        
        public IObservable<Unit> OnDied => _onDied;
        private readonly Subject<Unit> _onDied = new();
        
        public HealthModel(int maxHp)
        {
            MaxHP = maxHp;
            CurrentHP = new ReactiveProperty<int>(maxHp);
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHP.Value <= 0)
                return;
            
            CurrentHP.Value = Mathf.Max(0, CurrentHP.Value - damage);
            
            if (CurrentHP.Value <= 0)
            {
                _onDied.OnNext(Unit.Default);
                _onDied.OnCompleted();
            }
        }
    }
}