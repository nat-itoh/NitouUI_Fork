using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: LineRenderer��DOFade���g����悤�ɂ���g�����\�b�h https://baba-s.hatenablog.com/entry/2023/04/05/102559

namespace DG.Tweening {

    /// <summary>
    /// <see cref="LineRenderer"/>��Tween�֘A�̊g�����\�b�h�W
    /// </summary>
    public static partial class LineRendererTweenExtensions {

        /// --------------------------------------------------------------------
        #region Fading Tweens

        /// <summary>
        /// DOFade�̊g�����\�b�h
        /// </summary>
        public static Tweener DOFade(this LineRenderer self, float endValue, float duration) {

            var startColor = self.startColor;
            var endColor = self.endColor;

            return self.DOColor(
                    startValue: new(startColor, endColor),
                    endValue: new(
                        new Color(startColor.r, startColor.g, startColor.b, endValue),
                        new Color(endColor.r, endColor.g, endColor.b, endValue)
                    ),
                    duration: duration
                );
        }

        /// <summary>
        /// �t�F�[�h�A�E�g������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeOut(this LineRenderer self, float duration) =>
            self.DOFade(0.0F, duration);

        /// <summary>
        /// �t�F�[�h�C��������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeIn(this LineRenderer self, float duration) =>
            self.DOFade(1.0F, duration);
        #endregion

        /// --------------------------------------------------------------------
        #region Parameter Tweens

        /// <summary>
        /// <see cref="LineRenderer.widthMultiplier"/>���A�j���[�V����������g�����\�b�h
        /// </summary>
        public static Tweener DOParam_WidthMultiplier(this LineRenderer self, float endValue, float duration) {
            return DOTween.To(
                () => self.widthMultiplier,
                x => self.widthMultiplier = x,
                endValue,
                duration);
        }

        /// <summary>
        /// <see cref="LineRenderer.textureScale"/>���A�j���[�V����������g�����\�b�h
        /// </summary>
        public static Tweener DOParam_TextureScale(this LineRenderer self, Vector2 endValue, float duration) {
            return DOTween.To(
                () => self.textureScale,
                x => self.textureScale = x,
                endValue,
                duration);
        }

        #endregion
    }

}