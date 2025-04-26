using System;
using UniRx;
using UnityEngine;

namespace Core
{
    public interface IInputService
    {
        public IReadOnlyReactiveProperty<Vector2> Movement { get; }
        public IObservable<Unit> AttackPreformed { get; }
        
        public void Enable();
        public void Disable();
    }
}