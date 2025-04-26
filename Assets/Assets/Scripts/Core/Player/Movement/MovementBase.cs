using System;
using DataBase;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public abstract class MovementBase : IInitializable, IFixedTickable, IDisposable, IMovementSystem
    {
        protected PlayerView PlayerView;
        
        private IInputService _inputService;
        private AnimationController _animationController;
        
        protected readonly ReactiveProperty<Vector3> MoveDirection = new();
        private readonly CompositeDisposable _disposables = new();
        private PlayerConfig _playerConfig;

        protected float MoveSpeed = 5;

        [Inject]
        public void Construct(PlayerView playerView, IInputService inputService, PlayerConfig playerConfig)
        {
            PlayerView = playerView;
            _inputService = inputService;
            MoveSpeed = playerConfig.MoveSpeed;
        }

        public void Initialize()
        {
            SubscribeToInputEvents();
        }

        public void SetAnimator(AnimationController animationController)
        {
            _animationController = animationController;
        }
        
        private void SubscribeToInputEvents()
        {
            _inputService
                .Movement
                .Subscribe(OnInputReceived)
                .AddTo(_disposables);
        }

        private void OnInputReceived(Vector2 input) 
        {
            MoveDirection.Value = new Vector3(input.x, 0, input.y);
        }

        public void FixedTick()
        {
            if (MoveDirection.Value.magnitude > 0.1f)
            {
                Move();
                Rotate();
            }
            else
            {
                StopMovement(); 
            }
        }

        protected virtual void Move() => _animationController.SetMovement(1);

        protected abstract void Rotate();

        protected virtual void StopMovement() => _animationController.SetMovement(0);
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}