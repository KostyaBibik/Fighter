using System;
using UniRx;
using UnityEngine;

namespace Extensions
{
    public static class AsyncOperationExtensions
    {
        public static IObservable<AsyncOperation> ToObservable(this AsyncOperation asyncOp)
        {
            return Observable.FromEvent<AsyncOperation>(
                handler => asyncOp.completed += handler,
                handler => asyncOp.completed -= handler
            ).Take(1); 
        }
    }
}