using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityScreenNavigator.Runtime.Core.Modal;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {

    /// <summary>
    /// 確認モーダルの基底クラス
    /// </summary>
    public abstract class ConfirmModalBase : Modal {

        [TitleGroup("Text"), Indent]
        [SerializeField] protected TextMeshProUGUI _titleText;

        [TitleGroup("Text"), Indent]
        [SerializeField] protected TextMeshProUGUI _messageText;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// 表示テキストを設定する
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
        /// 終了処理
        /// </summary>
        public override Task Cleanup() {
            return base.Cleanup();
        }
    }
        

}