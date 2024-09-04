using UnityEngine;
using nitou;

namespace UnityScreenNavigator.Runtime.Core.Sheet {

    /// <summary>
    /// <see cref="Sheet"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class SheetExtensions {

        /// <summary>
        /// CanvasGroup��interctable�ݒ���s���g�����\�b�h
        /// </summary>
        public static void SetInteractable(this Sheet sheet, bool value) {
            var canvasGroup = sheet.GetOrAddComponent<CanvasGroup>();
            canvasGroup.interactable = value;
        }

    }
}