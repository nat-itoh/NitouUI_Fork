using System;

namespace nitou.UI.Component{

    /// <summary>
    /// "ValueChange"イベントを扱うUIであることを示すインターフェース
    /// </summary>
    public interface IUIValueChangeable{

        /// <summary>
        /// 値が変化した時のイベント通知
        /// </summary>
        public IObservable<float> OnValueChanged { get; }

    }
}
