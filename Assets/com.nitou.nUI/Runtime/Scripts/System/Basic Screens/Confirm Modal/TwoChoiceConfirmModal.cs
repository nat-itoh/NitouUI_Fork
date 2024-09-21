using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {
    using nitou.UI.Component;

    /// <summary>
    /// �Q�I�����̊m�F���[�_��
    /// </summary>
    public class TwoChoiceConfirmModal : ConfirmModalBase {

        /// ----------------------------------------------------------------------------
        // Field

        [TitleGroup("Buttons"), Indent]
        [SerializeField] private UIButton _yesButton;

        [TitleGroup("Buttons"), Indent]
        [SerializeField] private UIButton _noButton;


        /// ----------------------------------------------------------------------------
        // Properity

        public IObservable<Unit> OnYesButtonClicked => _yesButton.OnSubmited;
        public IObservable<Unit> OnNoButtonClicked => _noButton.OnSubmited;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �ǂ��炩�̃{�^�������������̂�ҋ@���邷��
        /// </summary>
        public UniTask<bool> WaitUntilClicked() {
            return Observable.Merge(
                   OnYesButtonClicked.Select(x => true),
                   OnNoButtonClicked.Select(x => false))
               .ToUniTask(useFirstValue: true);
        }
    }

}