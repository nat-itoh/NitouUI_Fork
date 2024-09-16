using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace nitou.UI.ScreenSystem {

    /// <summary>
    /// 
    /// </summary>
    public abstract class LifecycleModalBase : IModal, IModalLifecycleEvent, IDisposable {

        private readonly Modal _modal;
        private CancellationTokenSource _exitCancellationTokenSource;
        protected readonly CancellationTokenSource _disposeCancellationTokenSource;

        /// <summary>
        /// 
        /// </summary>
        public CancellationToken ExitCancellationToken => _exitCancellationTokenSource.Token;

        /// <summary>
        /// 
        /// </summary>
        public CancellationToken DisposeCancellationToken => _disposeCancellationTokenSource.Token;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="modal"></param>
        protected LifecycleModalBase(Modal modal) {
            _modal = modal;
            _modal.AddLifecycleEvent(this);
            _disposeCancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public virtual void Dispose() {
            _modal.RemoveLifecycleEvent(this);
            _disposeCancellationTokenSource.Cancel();
            _disposeCancellationTokenSource.Dispose();
        }


        #region IModal Lifecycle Events

        public virtual void DidPushEnter() { }

        public virtual void DidPushExit() { }

        public virtual void DidPopEnter() { }

        public virtual void DidPopExit() { }


#if USN_USE_ASYNC_METHODS

        async Task IModalLifecycleEvent.Initialize() {
            var cts = BuildCancellationTokenSourceOnDispose();
            await InitializeAsync(cts.Token);
            cts.Cancel();
        }

        async Task IModalLifecycleEvent.WillPushEnter() {
            EnableExitTokenSource(true);
            var cts = BuildCancellationTokenSourceOnDispose();
            await WillPushEnterAsync(cts.Token);
            cts.Cancel();
        }

        async Task IModalLifecycleEvent.WillPushExit() {
            EnableExitTokenSource(false);
            await WillPushExitAsync();
        }

        async Task IModalLifecycleEvent.WillPopEnter() {
            EnableExitTokenSource(true);
            var cts = BuildCancellationTokenSourceOnDispose();
            await WillPopEnterAsync(cts.Token);
            cts.Cancel();
        }

        async Task IModalLifecycleEvent.WillPopExit() {
            EnableExitTokenSource(false);
            var cts = BuildCancellationTokenSourceOnDispose();
            await WillPopExitAsync(cts.Token);
            cts.Cancel();
        }

        async Task IModalLifecycleEvent.Cleanup() {
            var cts = BuildCancellationTokenSourceOnDispose();
            await CleanUpAsync(cts.Token);
            cts.Cancel();
        }
#else
        IEnumerator IModalLifecycleEvent.Initialize() {
            var cts = BuildCancellationTokenSourceOnDispose();
            yield return InitializeAsync(cts.Token).ToCoroutine();
            cts.Cancel();
        }
 
        IEnumerator IModalLifecycleEvent.WillPushEnter() {
            EnableExitTokenSource(true);
            var cts = BuildCancellationTokenSourceOnDispose();
            yield return WillPushEnterAsync(cts.Token).ToCoroutine();
            cts.Cancel();
        }

        IEnumerator IModalLifecycleEvent.WillPushExit() {
            EnableExitTokenSource(false);
            yield return WillPushExitAsync().ToCoroutine();
        }

        IEnumerator IModalLifecycleEvent.WillPopEnter() {
            EnableExitTokenSource(true);
            var cts = BuildCancellationTokenSourceOnDispose();
            yield return WillPopEnterAsync(cts.Token).ToCoroutine();
            cts.Cancel();
        }

        IEnumerator IModalLifecycleEvent.WillPopExit() {
            EnableExitTokenSource(false);
            var cts = BuildCancellationTokenSourceOnDispose();
            yield return WillPopExitAsync(cts.Token).ToCoroutine();
            cts.Cancel();
        }

        IEnumerator IModalLifecycleEvent.Cleanup() {
            var cts = BuildCancellationTokenSourceOnDispose();
            yield return CleanUpAsync(cts.Token).ToCoroutine();
            cts.Cancel();
        }
#endif
        #endregion


        protected virtual UniTask InitializeAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;

        protected virtual UniTask WillPushEnterAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;

        protected virtual UniTask WillPushExitAsync() => UniTask.CompletedTask;

        protected virtual UniTask WillPopEnterAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;

        protected virtual UniTask WillPopExitAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;

        protected virtual UniTask CleanUpAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;




        private void EnableExitTokenSource(bool enable) {
            if (enable) {
                _exitCancellationTokenSource = BuildCancellationTokenSourceOnDispose();
            } else {
                _exitCancellationTokenSource.Cancel();
            }
        }

        private CancellationTokenSource BuildCancellationTokenSourceOnDispose() {
            return CancellationTokenSource.CreateLinkedTokenSource(_disposeCancellationTokenSource.Token);
        }

    }
}
