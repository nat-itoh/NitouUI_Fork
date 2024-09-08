using System;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    /// <summary>
    /// "Move"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUIMoveable : IUIComponent{

        /// <summary>
        /// �ړ����͂����������̃C�x���g�ʒm
        /// </summary>
        public IObservable<MoveDirection> OnMoved { get; }
    }
}
