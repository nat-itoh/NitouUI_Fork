using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Sirenix.OdinInspector;

namespace nitou.UI {
    using nitou.UI.Component;
    using nitou.UI.PresentationFramework;

    public sealed class TitleView : AppView<TitleViewState> {

        private const string BUTTON_GROUP = "Control";

        /// ----------------------------------------------------------------------------
        // Field & Properity

        /// <summary>
        /// ゲーム開始ボタン
        /// </summary>
        [TitleGroup(BUTTON_GROUP), Indent]
        public UIButton nextButton;


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override UniTask Initialize(TitleViewState viewState) {
            // 
            nextButton.OnSubmited.Subscribe(_ => viewState.InvokeNextButtonClicked()).AddTo(this);

            return UniTask.CompletedTask;
        }
    }
}
