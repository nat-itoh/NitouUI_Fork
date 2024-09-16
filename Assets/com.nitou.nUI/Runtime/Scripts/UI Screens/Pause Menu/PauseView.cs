using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace nitou.UI{
    using nitou.UI.Component;
    using nitou.UI.PresentationFramework;

    public sealed class PauseView : AppView<PauseViewState> {

        [Title(IKey.Button.CONTROL)]
        [SerializeField, Indent] UIButton _continueButton;
        [SerializeField, Indent] UIButton _restartButton;
        [SerializeField, Indent] UIButton _quitButton;


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override UniTask Initialize(PauseViewState viewState) {

            // バインド
            _continueButton.OnSubmited.Subscribe(_ => viewState.InvokeContinueEvent()).AddTo(this);
            _restartButton.OnSubmited.Subscribe(_ => viewState.InvokeRestartEvent()).AddTo(this);
            _quitButton.OnSubmited.Subscribe(_ => viewState.InvokeQuitEvent()).AddTo(this);

            return UniTask.CompletedTask;
        }

    }
}
