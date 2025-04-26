using System;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class EnemyPresenter : IAttackable, IDisposable
    {
        private readonly EnemyView _view;
        private readonly EnemyModel _model;
        private readonly EnemyRegistry _registry;
        private readonly CompositeDisposable _disposables = new();
        
        public Vector3 Position => _view.transform.position;
        public HealthModel Health => _model.Health;

        public EnemyPresenter(EnemyView view, EnemyModel model, EnemyRegistry registry)
        {
            _view = view;
            _model = model;
            _registry = registry;
            
            _registry.Register(this);
            
            _model
                .Health
                .OnDied
                .Subscribe(_ => Die())
                .AddTo(_disposables);
        }
        
        private void Die()
        {
            _registry.Unregister(this);
            Object.Destroy(_view.gameObject); 
            Dispose();
        }

        public void Dispose() =>
            _disposables?.Dispose();
    }
}