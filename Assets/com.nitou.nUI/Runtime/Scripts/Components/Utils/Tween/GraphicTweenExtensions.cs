using UnityEngine.UI;

namespace DG.Tweening {

    /// <summary>
    /// <see cref="Graphic"/>��Tween�֘A�̊g�����\�b�h�W
    /// </summary>
    public static class GraphicTweenExtensions {

        /// --------------------------------------------------------------------
        // �o���E�����A�j���[�V����

        /// <summary>
        /// �t�F�[�h�A�E�g������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeOut(this Graphic self, float duration) {
            return self.DOFade(0.0F, duration);
        }

        /// <summary>
        /// �t�F�[�h�C��������g�����\�b�h
        /// </summary>
        public static Tweener DOFadeIn(this Graphic canvasGroup, float duration) {
            return canvasGroup.DOFade(1.0F, duration);
        }
    }
}
