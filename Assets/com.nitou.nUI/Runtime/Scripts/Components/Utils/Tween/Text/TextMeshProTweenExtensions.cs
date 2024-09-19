using System;
using TMPro;

// [�Q�l]
//  qiita: DOTween�ŃJ�E���g�_�E���E�J�E���g�A�b�v�̃A�j���[�V���� https://qiita.com/RyotaMurohoshi/items/f7312e802f7698e42cd0
//  qiita: Unity1�T�ԃQ�[���W���� (�t) �ɂĎ����������o���܂Ƃ߂� https://qiita.com/lycoris102/items/30c3faaa6904c441cd71

namespace DG.Tweening {

    /// <summary>
    /// TextMeshPro��Tween���C�u�����N���X
    /// </summary>
    public static partial class TextMeshProTweenExtension {

        /// --------------------------------------------------------------------
        #region �������Tween

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextInt(this TextMeshProUGUI self, int startValue, int endValue, float duration, Func<int, string> convertor) {
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
        public static Tweener DOTextInt(this TextMeshProUGUI self, int startValue, int endValue, float duration) {
            return TextMeshProTweenExtension.DOTextInt(self, startValue, endValue, duration, it => it.ToString());
        }

        /// <summary>
        /// �J�E���g�_�E���E�J�E���g�A�b�v����g�����\�b�h
        /// </summary>
        public static Tweener DOTextFloat(this TextMeshProUGUI self, float startValue, float endValue, float duration, Func<float, string> convertor) {
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
        public static Tweener DOTextFloat(this TextMeshProUGUI self, float startValue, float endValue, float duration) {
            return TextMeshProTweenExtension.DOTextFloat(self, startValue, endValue, duration, it => it.ToString());
        }
        #endregion


        /// --------------------------------------------------------------------
        #region ���̑���Tween

        /// <summary>
        /// �����Ԋu��Tween����g�����\�b�h
        /// </summary>
        public static Tweener DOCharacterSpace(this TextMeshProUGUI self, float endValue, float duration) {
            return DOTween.To(
                 () => self.characterSpacing,
                 value => self.characterSpacing = value,
                 endValue,
                 duration
             );
        }

        /// <summary>
        /// �s�Ԋu��Tween����g�����\�b�h
        /// </summary>
        public static Tweener DOLineSpace(this TextMeshProUGUI self, float endValue, float duration) {
            return DOTween.To(
                 () => self.lineSpacing,
                 value => self.lineSpacing = value,
                 endValue,
                 duration
             );
        }
        #endregion
    }
}