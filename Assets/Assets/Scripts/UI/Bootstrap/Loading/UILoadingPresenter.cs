using System;
using UI.Abstract;
using UniRx;

namespace UI
{
    public class UILoadingPresenter : UIPresenter<UILoadingView>
    {
        private int _dotCount;
        
        private readonly CompositeDisposable _disposables = new();

        private const float Delay = .5f;

        public UILoadingPresenter(UILoadingView view) : base(view)
        {
        }

        public override void Initialize()
        {
            Observable.Interval(TimeSpan.FromSeconds(Delay))
                .Subscribe(_ => UpdateLoadingText())
                .AddTo(_disposables);
        }
        
        private void UpdateLoadingText()
        {
            _dotCount = (_dotCount + 1) % 4;
            var dots = new string('.', _dotCount);
            _view.Text.text = $"Loading{dots}";
        }

        public override void Dispose() =>
            _disposables?.Dispose();
    }
}