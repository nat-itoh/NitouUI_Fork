using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {
    using nitou.UI.Component;

    /// <summary>
    /// �P�I�����̊m�F���[�_��
    /// </summary>
    public class OneChiceConfirmModal : ConfirmModalBase {

        /// ----------------------------------------------------------------------------
        // Field

        [TitleGroup("Buttons"), Indent]
        [SerializeField] private UIButton _okButton;


        /// ----------------------------------------------------------------------------
        // Properity

        public IObservable<Unit> OnOkButtonClicked => _okButton.OnSubmited;


        /// ----------------------------------------------------------------------------
        // Public Method

        public UniTask WaitClick() {
            return OnOkButtonClicked.ToUniTask(useFirstValue: true);
        }
    }

}