using System;
using UniRx;

namespace nitou.UI.Component{

    /// <summary>
    /// "Pointer"イベントを扱うUIであることを示すインターフェース
    /// </summary>
    public interface IUIPointerable{

        /// <summary>
        /// ポインターが範囲内に入った時のイベント通知
        /// </summary>
        public IObservable<Unit> OnPointerEnter { get; }

        /// <summary>
        /// ポインターが範囲内から出た時のイベント通知
        /// </summary>
        public IObservable<Unit> OnPointerExit { get; }
    }
}
