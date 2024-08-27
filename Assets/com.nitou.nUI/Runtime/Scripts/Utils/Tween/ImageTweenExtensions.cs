using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using nitou;

namespace DG.Tweening {

    /// <summary>
    /// Image��Tween���C�u�����N���X�D�ėp�I�ȃA�j���[�V�������
    /// </summary>
    public static class ImageTweenExtensions {

        /// --------------------------------------------------------------------
        // �o���E�����A�j���[�V����

        /// <summary>
        /// 
        /// </summary>
        public static Sequence DOScaleMoveFlash(this Image image, float duration = 0.5f, float afterScale = 0.95f, float offset = 30f) {
            var rect = image.GetComponent<RectTransform>();
            return DOTween.Sequence()
                .Append(rect.DOScale(afterScale, duration).SetEase(Ease.InFlash, 2))
                .Join(rect.DOMoveY(offset, duration).SetRelative().SetEase(Ease.InFlash));
        }


        /// <summary>
        /// 
        /// </summary>
        public static Sequence DoFallApearenceWithShake(this Image image, float fallHeight = 50f, float duration = 0.5f, float afterScale = 0.95f, float offset = 10f) {

            // �������
            var rect = image.rectTransform;
            var initPos = rect.anchoredPosition;

            // �J�n����
            image.gameObject.SetActive(true);
            image.SetAlpha(0f);
            rect.anchoredPosition += new Vector2(0, fallHeight);

            // �A�j���[�V������`
            var seq = DOTween.Sequence()
                .Append(rect.DOAnchorPosY(initPos.y, duration).SetEase(Ease.OutQuart))
                .Join(image.DOFade(1, duration * 0.5f))
                .Join(rect.DOPunchRotation(Vector3.forward, duration, vibrato: 10, elasticity: 3))
                ;
            //.Join(target.DOScaleY(0.7f, duration * 0.5f).SetEase(Ease.InFlash, 10).SetDelay(duration * 0.5f))

            return seq;

        }


    }
}