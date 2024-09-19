using System;
using UniRx;
using UnityEngine.UI;

namespace nitou.UI.BasicScreen {
    using nitou.UI.PresentationFramework;

    public sealed class TitleViewState : AppViewState {

        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnClicked => _onClickedSubject;
        private readonly Subject<Unit> _onClickedSubject = new();


        /// ----------------------------------------------------------------------------
        // Public Method

        public void InvokeNextButtonClicked() {
            _onClickedSubject.OnNext(Unit.Default);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// èIóπèàóù
        /// </summary>
        protected override void DisposeInternal() {
            _onClickedSubject.Dispose();
        }
    }
}
