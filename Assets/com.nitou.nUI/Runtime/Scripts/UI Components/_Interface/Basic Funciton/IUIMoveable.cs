using System;
using UniRx;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    /// <summary>
    /// "Move"イベントを扱う自作UIであることを示すインターフェース
    /// </summary>
    public interface IUIMoveable : IUIComponent{

        /// <summary>
        /// 移動入力が入った時のイベント通知
        /// </summary>
        public IObservable<MoveDirection> OnMoved { get; }
    }
}
