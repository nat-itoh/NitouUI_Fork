using System;
using UniRx;
using UnityEngine.UI;

namespace nitou.UI.BasicScreen {
    using nitou.UI.PresentationFramework;

    public sealed class CreditViewState : AppViewState {

        public IObservable<Unit> OnBackButtonClicked => _onBackButtonClickedSubject;
        private readonly Subject<Unit> _onBackButtonClickedSubject = new();


        /// ----------------------------------------------------------------------------
        // Public Method (イベント発火)

        public void InvokeBackButtonClicked() => _onBackButtonClickedSubject.OnNext(Unit.Default);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 終了処理
        /// </summary>
        protected override void DisposeInternal() {
            _onBackButtonClickedSubject.Dispose();
        }
    }

}
