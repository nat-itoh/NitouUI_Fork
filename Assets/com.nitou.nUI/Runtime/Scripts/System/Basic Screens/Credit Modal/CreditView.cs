using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {
    using nitou.UI.Component;
    using nitou.UI.PresentationFramework;

    public sealed class CreditView : AppView<CreditViewState> {

        [Title(IKey.Button.CONTROL)]
        [SerializeField, Indent] UIButton _backButton;


        /// ----------------------------------------------------------------------------
        // Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override UniTask Initialize(CreditViewState viewState) {

            // バインド
            _backButton.OnSubmited.Subscribe(_ => viewState.InvokeBackButtonClicked()).AddTo(this);

            return UniTask.CompletedTask;
        }

    }
}
