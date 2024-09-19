using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {
    using nitou.UI.Component;

    /// <summary>
    /// ２選択肢の確認モーダル
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

        public UniTask<bool> WaitInputValue() {
             return OnYesButtonClicked.Select(x => true)
                .Merge(OnNoButtonClicked.Select(x => false))
                .ToUniTask(useFirstValue: true);
        }
    }

}