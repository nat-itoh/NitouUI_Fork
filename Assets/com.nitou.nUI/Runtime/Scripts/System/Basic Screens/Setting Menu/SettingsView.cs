using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.BasicScreen {
    using nitou.UI.Component;
    using nitou.UI.PresentationFramework;

    public sealed class SettingsView : AppView<SettingsViewState> {

        /// ----------------------------------------------------------------------------
        // Inspecter Group

        private const string CONTENTS_GROUP = "Contents";
        private const string BUTTON_GROUP = "Buttons";


        /// ----------------------------------------------------------------------------
        // Field 

        [TitleGroup(CONTENTS_GROUP), Indent]
        public SoundSettingsView SoundSettingsView;

        // --- 

        [TitleGroup(BUTTON_GROUP), Indent]
        public UIButton CloseButton;


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override async UniTask Initialize(SettingsViewState viewState) {

            // 
            await SoundSettingsView.InitializeAsync(viewState.SoundSettings);

            CloseButton.OnSubmited.Subscribe(_ => viewState.InvokeCloseButtonClicked()).AddTo(this);

            await UniTask.CompletedTask;
        }

    }
}
