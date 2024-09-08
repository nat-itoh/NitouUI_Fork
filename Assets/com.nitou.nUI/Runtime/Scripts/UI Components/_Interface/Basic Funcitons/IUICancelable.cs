using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Cancel"イベントを扱うUIであることを示すインターフェース
    /// </summary>
    public interface IUICancelable : IUIComponent {

        /// <summary>
        /// キャンセル入力された時のイベント通知
        /// </summary>
        public IObservable<Unit> OnCanceled { get; }
    }
}
