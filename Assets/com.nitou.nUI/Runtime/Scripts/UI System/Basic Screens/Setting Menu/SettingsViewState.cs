using System;
using UniRx;

namespace nitou.UI {
    using nitou.UI.PresentationFramework;

    public sealed class SettingsViewState : AppViewState  {

        private readonly Subject<Unit> _onCloseButtonClickedSubject = new();
        
        /// <summary>
        /// クリック時のイベント通知
        /// </summary>
        public IObservable<Unit> OnCloseButtonClicked => _onCloseButtonClickedSubject;

        /// <summary>
        /// サウンド設定
        /// </summary>
        public SoundSettingsViewState SoundSettings { get; } = new();


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// 閉じるボタンの実行
        /// </summary>
        public void InvokeCloseButtonClicked() {
            _onCloseButtonClickedSubject.OnNext(Unit.Default);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 終了処理
        /// </summary>
        protected override void DisposeInternal() {
            SoundSettings.Dispose();
            _onCloseButtonClickedSubject.Dispose();
        }
    }
}
