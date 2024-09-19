using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Overlay {

    /// <summary>
    /// �V���v���ȃt�F�[�h�C���E�t�F�[�h�A�E�g�̊W�G
    /// </summary>
    public class Overlay_SimpleFade : OverlayBase {

        [Title("Tween Parameters")]
        [SerializeField, Indent] Ease _openEasing = Ease.OutQuad;
        [SerializeField, Indent] Ease _closeEasing = Ease.OutQuad;

        private Tween _tween;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Methord 

        private void OnDestroy() {
            _tween?.Kill();    
        }


        /// ----------------------------------------------------------------------------
        // Public Methord (�J�ڃA�j���[�V����)

        /// <summary>
        /// Progress: 1��0�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        protected override UniTask OpenInternal(float duration) {
            _tween?.Kill();
            _tween = _canvasGroup
                .DOFade(0f, duration).From(1f).SetEase(_openEasing)
                .IgnoreTimeScale();

            return _tween.ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }

        /// <summary>
        /// Progress: 0��1�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        protected override UniTask CloseInternal(float duration) {
            _tween?.Kill();
            _tween = _canvasGroup
                .DOFade(1f, duration).From(0f).SetEase(_closeEasing)
                .IgnoreTimeScale();

            return _tween.ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
        }

    }
}
