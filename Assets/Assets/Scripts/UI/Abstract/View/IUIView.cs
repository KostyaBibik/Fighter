using System;
using Cysharp.Threading.Tasks;
using UniRx;

namespace UI.Abstract
{
    public interface IUIView : IDisposable
    {
        public ReactiveCommand<Unit> OnInit { get; }
        public ReactiveCommand<Unit> OnShow { get; }
        public ReactiveCommand<Unit> OnHide { get; }
        public UniTask Show(bool instant = true);
        public UniTask Hide(bool instant = true);
    }
}