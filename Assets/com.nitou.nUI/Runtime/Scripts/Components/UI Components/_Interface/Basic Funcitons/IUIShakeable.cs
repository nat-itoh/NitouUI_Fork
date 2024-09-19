using System;
using UniRx;
using UnityEngine;

namespace nitou.UI.Component{

    /// <summary>
    /// "Shake"イベントを扱うUIであることを示すインターフェース
    /// </summary>
    public interface IUIShakeable : IUIComponent {

        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnMoveNext { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnMovePrevious { get; }
    
    }
}
