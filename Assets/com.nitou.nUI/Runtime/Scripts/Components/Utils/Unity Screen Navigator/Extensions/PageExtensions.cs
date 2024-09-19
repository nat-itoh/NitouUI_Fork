using UnityEngine;
using nitou;

namespace UnityScreenNavigator.Runtime.Core.Page{

    /// <summary>
    /// <see cref="Page"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class PageExtensions {

        /// <summary>
        /// CanvasGroup��interctable�ݒ���s���g�����\�b�h
        /// </summary>
        public static void SetInteractable(this Page page, bool value) {
            var canvasGroup = page.GetOrAddComponent<CanvasGroup>();
            canvasGroup.interactable = value;
        }

    }
}
