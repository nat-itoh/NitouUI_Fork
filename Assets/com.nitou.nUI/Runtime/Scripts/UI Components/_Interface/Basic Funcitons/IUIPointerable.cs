using System;
using UniRx;

namespace nitou.UI.Component{

    /// <summary>
    /// "Pointer"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUIPointerable{

        /// <summary>
        /// �|�C���^�[���͈͓��ɓ��������̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnPointerEnter { get; }

        /// <summary>
        /// �|�C���^�[���͈͓�����o�����̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnPointerExit { get; }
    }
}
