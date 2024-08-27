using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Submit"�C�x���g����������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUISubmitable : IUIComponent {

        /// <summary>
        /// ������͂��ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSubmited { get; }
    }

}