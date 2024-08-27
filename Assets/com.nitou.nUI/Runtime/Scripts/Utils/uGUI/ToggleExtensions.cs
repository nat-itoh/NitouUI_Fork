using System;
using UniRx;
using UnityEngine.UI;

namespace nitou {

    /// <summary>
    ///  Toggle�̊g�����\�b�h�N���X
    /// </summary>
    public static class ToggleExtensions {

        /// ----------------------------------------------------------------------------
        // �C�x���g�̓o�^

        /// <summary>
        /// �C�x���g��o�^����g�����\�b�h
        /// </summary>
        public static IDisposable SetOnValueChangedDestination(this Toggle self, Action<bool> onValueChanged) {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }
    }
}
