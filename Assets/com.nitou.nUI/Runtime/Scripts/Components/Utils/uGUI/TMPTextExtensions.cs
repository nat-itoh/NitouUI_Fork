using System;
using UniRx;

namespace TMPro {

    /// <summary>
    /// TMPText�̊g�����\�b�h�N���X
    /// </summary>
    public static partial class TMPTextExtensions {

        /// <summary>
        /// �w�肵���X�g���[�g����\��������g�����\�b�h
        /// </summary>
        public static IDisposable SetTextSource(this TMP_Text self, IObservable<string> source) {
            return source
                .Subscribe(x => { self.text = x; })
                .AddTo(self);
        }

        /// <summary>
        /// �w�肵���X�g���[�g����\��������g�����\�b�h
        /// </summary>
        public static IDisposable SetTextSource(this TMP_Text self, IObservable<int> source, Func<int, string> converter = null) {
            return source
                .Subscribe(x => {
                    var text = converter == null ? x.ToString() : converter(x);
                    self.text = text;
                })
                .AddTo(self);
        }
    }
}
