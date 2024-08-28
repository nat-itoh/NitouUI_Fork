using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Cancel"イベントを扱う自作UIであることを示すインターフェース
    /// </summary>
    public interface IUICancelable : IUIComponent {

        /// <summary>
        /// キャンセル入力された時のイベント通知
        /// </summary>
        public IObservable<Unit> OnCanceled { get; }
    }
}
