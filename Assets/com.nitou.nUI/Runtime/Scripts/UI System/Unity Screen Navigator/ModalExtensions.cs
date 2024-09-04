using System;
using UnityEngine;
using nitou;

namespace UnityScreenNavigator.Runtime.Core.Modal {

    /// <summary>
    /// <see cref="Modal"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class ModalExtensions{

        /// <summary>
        /// CanvasGroup��interctable�ݒ���s���g�����\�b�h
        /// </summary>
        public static void SetInteractable(this Modal modal, bool value) {
            var canvasGroup = modal.GetOrAddComponent<CanvasGroup>();
            canvasGroup.interactable = value;
        }
        
    }
}
