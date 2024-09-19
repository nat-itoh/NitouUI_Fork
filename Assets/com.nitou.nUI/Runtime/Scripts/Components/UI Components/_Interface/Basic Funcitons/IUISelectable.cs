using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Select"イベントを扱うUIであることを示すインターフェース
    /// </summary>
    public interface IUISelectable : IUIComponent {

        /// <summary>
        /// 選択された時のイベント通知
        /// </summary>
        public IObservable<Unit> OnSelected { get; }

        /// <summary>
        /// 非選択された時のイベント通知
        /// </summary>
        public IObservable<Unit> OnDeselected { get; }
    }

}