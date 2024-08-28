using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Submit"イベントを扱う自作UIであることを示すインターフェース
    /// </summary>
    public interface IUISubmitable : IUIComponent {

        /// <summary>
        /// 決定入力された時のイベント通知
        /// </summary>
        public IObservable<Unit> OnSubmited { get; }
    }

}