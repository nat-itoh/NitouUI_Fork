using UnityEngine;

namespace DG.Tweening {

    /// <summary>
    /// <see cref="CanvasGroup"/>��Tween�֘A�̊g�����\�b�h�W
    /// </summary>
    public static class CanvasGrouopTweenExtensions {

        /// --------------------------------------------------------------------
        #region Fading Tweens

        /// <summary>
        /// �t�F�[�h�A�E�g������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeOut(this CanvasGroup self, float duration) {
            return self.DOFade(0.0F, duration);
        }

        /// <summary>
        /// �t�F�[�h�C��������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeIn(this CanvasGroup canvasGroup, float duration) {
            return canvasGroup.DOFade(1.0F, duration);
        }
        #endregion
    }

}