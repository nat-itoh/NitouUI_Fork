using System;
using UnityEngine.UI;

// [�Q�l]
//  qiita: DOTween�ŃJ�E���g�_�E���E�J�E���g�A�b�v�̃A�j���[�V���� https://qiita.com/RyotaMurohoshi/items/f7312e802f7698e42cd0

namespace DG.Tweening {

    /// <summary>
    /// Text��Tween���C�u�����N���X
    /// </summary>
    public static partial class TextTweenExtensions {

        /// --------------------------------------------------------------------
        #region �������Tween

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextInt(this Text self, int startValue, int endValue, float duration, Func<int, string> convertor) {
            return DOTween.To(
                 () => startValue,
                 it => self.text = convertor(it),
                 endValue,
                 duration
             );
        }

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextInt(this Text self, int startValue, int endValue, float duration) {
            return TextTweenExtensions.DOTextInt(self, startValue, endValue, duration, it => it.ToString());
        }

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextFloat(this Text self, float startValue, float endValue, float duration, Func<float, string> convertor) {
            return DOTween.To(
                 () => startValue,
                 it => self.text = convertor(it),
                 endValue,
                 duration
             );
        }

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextFloat(this Text self, float startValue, float endValue, float duration) {
            return TextTweenExtensions.DOTextFloat(self, startValue, endValue, duration, it => it.ToString());
        }
        #endregion

    }

}
