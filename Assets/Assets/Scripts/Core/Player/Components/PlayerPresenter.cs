using System;
using UniRx;
using UnityEngine;

namespace Core
{
    public class PlayerPresenter : IAttackable, IDisposable
    {
        private readonly PlayerView _view;
        private readonly PlayerModel _model;
        private readonly IAttacker _playerAttacker;
        private readonly CompositeDisposable _disposables = new();

        public IAttacker PlayerAttacker => _playerAttacker;
        public HealthModel Health => _model.Health;
        public Vector3 Position {
            get
            {
                if (_view == null || _view.transform == null)
                    return Vector3.zero;

                return _view.transform.position;
            }
        }

        public PlayerPresenter(PlayerView view, PlayerModel model, IAttacker playerAttacker)
        {
            _view = view;
            _model = model;
            _playerAttacker = playerAttacker;
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}