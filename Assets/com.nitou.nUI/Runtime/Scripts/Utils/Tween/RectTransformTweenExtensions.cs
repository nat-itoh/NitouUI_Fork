using UnityEngine;
using nitou;

// [�Q�l]
//  �˂������V�e�B: RectTransform�̃T�C�Y���X�N���v�g����ύX���� https://nekojara.city/unity-rect-transform-size

namespace DG.Tweening{

    /// <summary>
    /// RectTransform��Tween���C�u�����N���X
    /// </summary>
    public static class RectTransformTweenExtensions{

        /// <summary>
        /// �A���J�[���Œ肳����SizeDelta���A�j���[�V����������g�����\�b�h
        /// </summary>
        public static Tweener DOSizeDeltaWithCurrentAnchers(this RectTransform self, Vector2 endValue, float duration) {
            return DOTween.To(
                () => self.sizeDelta, 
                x => self.SetSize(x), 
                endValue, 
                duration
            );
        }
        
    }
}
