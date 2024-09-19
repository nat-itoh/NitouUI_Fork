using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityScreenNavigator.Runtime.Core.Modal;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {

    /// <summary>
    /// �m�F���[�_���̊��N���X
    /// </summary>
    public abstract class ConfirmModalBase : Modal {

        [TitleGroup("Text"), Indent]
        [SerializeField] protected TextMeshProUGUI _titleText;

        [TitleGroup("Text"), Indent]
        [SerializeField] protected TextMeshProUGUI _messageText;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �\���e�L�X�g��ݒ肷��
        /// </summary>
        public void SetText(string title, string message) {
            if (_titleText != null) {
                _titleText.text = title;
            }

            if (_messageText != null) {
                _messageText.text = message;
            }
        }

        /// ----------------------------------------------------------------------------
        // Override Method

        /// <summary>
        /// �I������
        /// </summary>
        public override Task Cleanup() {
            return base.Cleanup();
        }
    }
        

}