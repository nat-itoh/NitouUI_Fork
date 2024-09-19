using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace nitou.UI.Overlay{

    /// <summary>
    /// �I�[�o�[���C��ʂ̃C���^�[�t�F�[�X
    /// </summary>
    public interface IUIOverlay{

        /// <summary>
        /// Progress: 1��0�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        public UniTask OpenAsync(float duration = 1f);

        /// <summary>
        /// Progress: 0��1�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        public UniTask CloseAsync(float duration = 1f);
    }


    /// <summary>
    /// <see cref="IUIOverlay"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class IUIOverlayExtensions {

        /// <summary>
        /// Progress: 0��1��0�̉�ʑJ�ڃA�j���[�V����
        /// </summary>
        public static async UniTask PlayAll(this IUIOverlay overlay, 
            float closeDuration = 0.5f, float waitDuration = 1f, float openDuration = 0.5f,
            CancellationToken cancellationToken = default) {

            if (overlay == null) throw new System.ArgumentNullException(nameof(overlay));

            // 
            await overlay.CloseAsync(closeDuration);
            await UniTask.WaitForSeconds(waitDuration, true, cancellationToken: cancellationToken);
            await overlay.OpenAsync(openDuration);
        }
    }
}
