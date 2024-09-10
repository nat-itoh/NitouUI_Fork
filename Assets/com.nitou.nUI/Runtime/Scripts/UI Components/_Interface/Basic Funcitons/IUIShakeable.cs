using System;
using UniRx;
using UnityEngine;

namespace nitou.UI.Component{

    /// <summary>
    /// "Shake"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
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
