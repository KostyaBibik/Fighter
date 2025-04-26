using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core
{
    public class InputSystemProvider : IInputService, IInitializable, IDisposable
    {
        private GameInputMap _inputActions;
        
        private readonly CompositeDisposable _disposables = new();
        private readonly ReactiveProperty<Vector2> _movement = new();
        private readonly Subject<Unit> _attackPreformed = new();
        
        public IReadOnlyReactiveProperty<Vector2> Movement => _movement;
        public IObservable<Unit> AttackPreformed => _attackPreformed;

        public void Initialize()
        {
            _inputActions = new GameInputMap();
            
            _inputActions.Control.Movement2D.performed += OnMovementPerformed;
            _inputActions.Control.Movement2D.canceled += OnMovementCanceled;
            _inputActions.Control.Attack.performed += OnAttackPerformed;
            
            Enable();
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            _movement.Value = context.ReadValue<Vector2>();
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            _movement.Value = Vector2.zero;
        }
        
        private void OnAttackPerformed(InputAction.CallbackContext context)
        {
            _attackPreformed.OnNext(Unit.Default); 
        }
        
        public void Enable() => _inputActions.Enable();

        public void Disable() => _inputActions.Disable();
        
        public void Dispose()
        {
            _inputActions.Control.Movement2D.performed -= OnMovementPerformed;
            _inputActions.Control.Movement2D.canceled -= OnMovementCanceled;
        
            _disposables.Dispose();
            _inputActions.Dispose();
        }
    }
}