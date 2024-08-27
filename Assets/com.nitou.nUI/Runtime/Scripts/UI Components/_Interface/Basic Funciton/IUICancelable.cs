using System;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// "Cancel"�C�x���g����������UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IUICancelable : IUIComponent {

        /// <summary>
        /// �L�����Z�����͂��ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnCanceled { get; }
    }
}
