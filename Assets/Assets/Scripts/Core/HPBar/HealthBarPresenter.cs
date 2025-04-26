using System;
using UniRx;

namespace Core
{
    public class HealthBarPresenter : IDisposable
    {
        private readonly HealthModel _model;
        private readonly HealthBarView _view;
        private readonly CompositeDisposable _disposables = new();

        public HealthBarPresenter(HealthModel model, HealthBarView view)
        {
            _model = model;
            _view = view;

            _model
                .CurrentHP
                .Subscribe(UpdateView)
                .AddTo(_disposables);

            UpdateView(_model.CurrentHP.Value);
        }

        private void UpdateView(int current)
        {
            var normalized = (float)current / _model.MaxHP;
            _view.SetNormalizedValue(normalized);
        }

        public void Dispose() => 
            _disposables.Dispose();
    }
}