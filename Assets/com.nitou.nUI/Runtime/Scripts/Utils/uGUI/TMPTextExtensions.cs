using System;
using UniRx;

namespace TMPro {

    /// <summary>
    /// TMPTextの拡張メソッドクラス
    /// </summary>
    public static partial class TMPTextExtensions {

        /// <summary>
        /// 指定したストリート情報を表示させる拡張メソッド
        /// </summary>
        public static IDisposable SetTextSource(this TMP_Text self, IObservable<string> source) {
            return source
                .Subscribe(x => { self.text = x; })
                .AddTo(self);
        }

        /// <summary>
        /// 指定したストリート情報を表示させる拡張メソッド
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
