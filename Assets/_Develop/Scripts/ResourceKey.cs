namespace Develop.Foundation {

    public static partial class ResourceKey {

        /// <summary>
        /// 
        /// </summary>
        public static class UI {

            // リソース情報
            private const string SHEET_PATH = "Sheet";
            private const string PAGE_PATH = "Page";
            private const string MODAL_PATH = "Modal";

            // コンテナ
            public const string PageContainer = "MainPageContainer";
            public const string ModalContainer = "MainModalContainer";


            /// ----------------------------------------------------------------------------
            // Sheet

            /// <summary>
            /// タイトル画面
            /// </summary>
            public static string TitleSheet => $"{SHEET_PATH}/Prefab_Title_Sheet";


            /// ----------------------------------------------------------------------------
            // Page

            /// <summary>
            /// タイトル画面
            /// </summary>
            public static string TitlePage => $"{PAGE_PATH}/Prefab_Title_Page";

            /// <summary>
            /// メニュー画面
            /// </summary>
            public static string TopMenuPage => $"{PAGE_PATH}/Prefab_TopMenu_Page";

            /// <summary>
            /// ロード画面
            /// </summary>
            public static string LoadingPage => $"{PAGE_PATH}/Prefab_Loading_Page";

            /// <summary>
            /// ステージ選択画面
            /// </summary>
            public static string StageSelectPage => $"{PAGE_PATH}/Prefab_StageSelect_Page";

            /// <summary>
            /// キャラクター画面
            /// </summary>
            public static string CharacterMenuPage => $"{PAGE_PATH}/Prefab_CharacterMenu_Page";

            /// <summary>
            /// HUD画面
            /// </summary>
            public static string HUDPage => $"{PAGE_PATH}/Prefab_HUD_Page";

            /// <summary>
            /// ステージ画面
            /// </summary>
            public static string StagePage => $"{PAGE_PATH}/Prefab_Stage_Page";



            /// ----------------------------------------------------------------------------
            // Modal

            /// <summary>
            /// 確認画面
            /// </summary>
            public static string ConfirmModal01 => $"{MODAL_PATH}/Confirm/Prefab_Confirm_OneChoice_Modal";

            /// <summary>
            /// 確認画面
            /// </summary>
            public static string ConfirmModal02 => $"{MODAL_PATH}/Confirm/Prefab_Confirm_TwoChoice_Modal";

            /// <summary>
            /// コマンドリスト画面
            /// </summary>
            public static string CommandListModal => $"{MODAL_PATH}/Command/Prefab_CommandList_Modal";


            /// <summary>
            /// 設定画面
            /// </summary>
            public static string SettingsModal => $"{MODAL_PATH}/Prefab_Settings_Modal";

            /// <summary>
            /// クレジット画面
            /// </summary>
            public static string CreditModal => $"{MODAL_PATH}/Prefab_Credit_Modal";

            /// <summary>
            /// レコード画面
            /// </summary>
            public static string RecordModal => $"{MODAL_PATH}/Prefab_Record_Modal";

            /// <summary>
            /// ポーズ画面
            /// </summary>
            public static string PauseModal => $"{MODAL_PATH}/Prefab_Pause_Modal";

            /// <summary>
            /// リザルト画面
            /// </summary>
            public static string ResultModal => $"{MODAL_PATH}/Prefab_Result_Modal";
        }


        public static class Overlay {

            private const string OVERLAY_PATH = "Overlay";

            /// ----------------------------------------------------------------------------

            /// <summary>
            /// 通常の遷移画面
            /// </summary>
            public static string BasicPanel => $"{OVERLAY_PATH}/Prefab_Basic_Panel";

        }


        public static class Audio {

        }

    }
}
