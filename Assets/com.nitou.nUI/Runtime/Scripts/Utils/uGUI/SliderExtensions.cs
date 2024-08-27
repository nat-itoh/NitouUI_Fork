using System;
using UniRx;
using UnityEngine.UI;

namespace nitou {

    /// <summary>
    /// Slider�̊g�����\�b�h�N���X
    /// </summary>
    public static class SliderExtensions {

        /// ----------------------------------------------------------------------------
        // �C�x���g�̓o�^

        /// <summary>
        /// �C�x���g��o�^����g�����\�b�h
        /// </summary>
        public static IDisposable SetOnValueChangedDestination(this Slider self, Action<float> onValueChanged) {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }

    }
}
