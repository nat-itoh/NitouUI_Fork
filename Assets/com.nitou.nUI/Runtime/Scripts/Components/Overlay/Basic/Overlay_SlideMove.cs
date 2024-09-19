using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Overlay {

    public class Overlay_SlideMove : OverlayBase {

        [Title("Tween Parameters")]
        [SerializeField, Indent] RectTransform _leftSide;
        [SerializeField, Indent] RectTransform _rightSide;
        [SerializeField, Indent] Ease _openEasing = Ease.Linear;
        [SerializeField, Indent] Ease _closeEasing = Ease.Linear;

        private Tween _tween;
        private Vector3 _leftOpenPos;
        private Vector3 _rightOpenPos;

        private Vector3 _leftClosedPos;
        private Vector3 _rightClosedPos;

        private float MoveDelta = 1920;


        protected override void Initialize() {
            // �����ʒu
            _leftOpenPos = _leftSide.position;
            _rightOpenPos = _rightSide.position;

            // �ړI�ʒu
            _leftClosedPos = _leftOpenPos + Vector3.right * MoveDelta;
            _rightClosedPos = _rightOpenPos + Vector3.left * MoveDelta;
        }


        /// ----------------------------------------------------------------------------
        // Public Methord (�J�ڃA�j���[�V����)

        /// <summary>
        /// Progress: 1��0�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        protected override UniTask OpenInternal(float duration) {
            _tween?.Kill();
            _tween = DOTween.Sequence()
                .Join(_leftSide.DOMove(_leftOpenPos, duration).SetEase(_openEasing))
                .Join(_rightSide.DOMove(_rightOpenPos, duration).SetEase(_openEasing))
                .IgnoreTimeScale();

            return _tween.ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }

        /// <summary>
        /// Progress: 0��1�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        protected override UniTask CloseInternal(float duration) {
            _tween?.Kill();
            _tween = DOTween.Sequence()
                .Join(_leftSide.DOMove(_leftClosedPos, duration).SetEase(_closeEasing))
                .Join(_rightSide.DOMove(_rightClosedPos, duration).SetEase(_closeEasing))
                .IgnoreTimeScale();

            return _tween.ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }
    }
}
