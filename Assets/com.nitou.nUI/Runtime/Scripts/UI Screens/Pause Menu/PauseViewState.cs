using System;
using UniRx;

namespace nitou.UI {
    using nitou.UI.PresentationFramework;

    public sealed class PauseViewState : AppViewState {

        private readonly Subject<Unit> _onContinueSubject = new();
        private readonly Subject<Unit> _onRestartSubject = new();
        private readonly Subject<Unit> _onQuitSubject = new();

        public IObservable<Unit> OnContinue => _onContinueSubject;
        public IObservable<Unit> OnRestart => _onRestartSubject;
        public IObservable<Unit> OnQuit => _onQuitSubject;


        /// ----------------------------------------------------------------------------
        // Public Method (イベント発火)

        public void InvokeContinueEvent() => _onContinueSubject.OnNext(Unit.Default);
        public void InvokeRestartEvent() => _onRestartSubject.OnNext(Unit.Default);
        public void InvokeQuitEvent() => _onQuitSubject.OnNext(Unit.Default);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 終了処理
        /// </summary>
        protected override void DisposeInternal() {
            _onContinueSubject.Dispose();
            _onRestartSubject.Dispose();
            _onQuitSubject.Dispose();
        }
    }

}
