using System;

namespace nitou.UI.Component{

    /// <summary>
    /// "ValueChange"�C�x���g������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUIValueChangeable{

        /// <summary>
        /// �l���ω��������̃C�x���g�ʒm
        /// </summary>
        public IObservable<float> OnValueChanged { get; }

    }
}
