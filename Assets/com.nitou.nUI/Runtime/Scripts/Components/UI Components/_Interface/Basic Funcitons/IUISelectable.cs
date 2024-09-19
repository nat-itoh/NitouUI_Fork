using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Select"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUISelectable : IUIComponent {

        /// <summary>
        /// �I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSelected { get; }

        /// <summary>
        /// ��I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnDeselected { get; }
    }

}