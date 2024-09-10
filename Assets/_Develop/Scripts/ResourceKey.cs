namespace Develop.Foundation {

    public static partial class ResourceKey {

        /// <summary>
        /// 
        /// </summary>
        public static class UI {

            // ���\�[�X���
            private const string SHEET_PATH = "Sheet";
            private const string PAGE_PATH = "Page";
            private const string MODAL_PATH = "Modal";

            // �R���e�i
            public const string PageContainer = "MainPageContainer";
            public const string ModalContainer = "MainModalContainer";


            /// ----------------------------------------------------------------------------
            // Sheet

            /// <summary>
            /// �^�C�g�����
            /// </summary>
            public static string TitleSheet => $"{SHEET_PATH}/Prefab_Title_Sheet";


            /// ----------------------------------------------------------------------------
            // Page

            /// <summary>
            /// �^�C�g�����
            /// </summary>
            public static string TitlePage => $"{PAGE_PATH}/Prefab_Title_Page";

            /// <summary>
            /// ���j���[���
            /// </summary>
            public static string TopMenuPage => $"{PAGE_PATH}/Prefab_TopMenu_Page";

            /// <summary>
            /// ���[�h���
            /// </summary>
            public static string LoadingPage => $"{PAGE_PATH}/Prefab_Loading_Page";

            /// <summary>
            /// �X�e�[�W�I�����
            /// </summary>
            public static string StageSelectPage => $"{PAGE_PATH}/Prefab_StageSelect_Page";

            /// <summary>
            /// �L�����N�^�[���
            /// </summary>
            public static string CharacterMenuPage => $"{PAGE_PATH}/Prefab_CharacterMenu_Page";

            /// <summary>
            /// HUD���
            /// </summary>
            public static string HUDPage => $"{PAGE_PATH}/Prefab_HUD_Page";

            /// <summary>
            /// �X�e�[�W���
            /// </summary>
            public static string StagePage => $"{PAGE_PATH}/Prefab_Stage_Page";



            /// ----------------------------------------------------------------------------
            // Modal

            /// <summary>
            /// �m�F���
            /// </summary>
            public static string ConfirmModal01 => $"{MODAL_PATH}/Confirm/Prefab_Confirm_OneChoice_Modal";

            /// <summary>
            /// �m�F���
            /// </summary>
            public static string ConfirmModal02 => $"{MODAL_PATH}/Confirm/Prefab_Confirm_TwoChoice_Modal";

            /// <summary>
            /// �R�}���h���X�g���
            /// </summary>
            public static string CommandListModal => $"{MODAL_PATH}/Command/Prefab_CommandList_Modal";


            /// <summary>
            /// �ݒ���
            /// </summary>
            public static string SettingsModal => $"{MODAL_PATH}/Prefab_Settings_Modal";

            /// <summary>
            /// �N���W�b�g���
            /// </summary>
            public static string CreditModal => $"{MODAL_PATH}/Prefab_Credit_Modal";

            /// <summary>
            /// ���R�[�h���
            /// </summary>
            public static string RecordModal => $"{MODAL_PATH}/Prefab_Record_Modal";

            /// <summary>
            /// �|�[�Y���
            /// </summary>
            public static string PauseModal => $"{MODAL_PATH}/Prefab_Pause_Modal";

            /// <summary>
            /// ���U���g���
            /// </summary>
            public static string ResultModal => $"{MODAL_PATH}/Prefab_Result_Modal";
        }


        public static class Overlay {

            private const string OVERLAY_PATH = "Overlay";

            /// ----------------------------------------------------------------------------

            /// <summary>
            /// �ʏ�̑J�ډ��
            /// </summary>
            public static string BasicPanel => $"{OVERLAY_PATH}/Prefab_Basic_Panel";

        }


        public static class Audio {

        }

    }
}
