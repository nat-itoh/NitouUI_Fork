#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;

// [�Q�l]
//  �͂Ȃ���: Player Settings��ScriptingDefineSymbols���X�N���v�g����擾�E�ݒ肷����@ https://www.hanachiru-blog.com/entry/2024/06/03/120000

namespace nitou.UI.EditorScripts {

    /// <summary>
    /// �V���{���̐ݒ���s���N���X
    /// </summary>
    [InitializeOnLoad]
    internal static class DefineSymbolsSetter{

        // ��`�������V���{���̔z��
        private static readonly string[] SYMBOL_ARRAY = {
            // UnityScreenNavigator��Task���g�p���邽�߂ɕK�v
            "USN_USE_ASYNC_METHODS",
            // DOTween��ToUnitask()���g�p���邽�߂ɕK�v
            "UNITASK_DOTWEEN_SUPPORT"
        };

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static DefineSymbolsSetter() {
            // �p�b�P�[�W���C���X�g�[�����ꂽ�Ƃ��Ɏ��s����鏈��
            AddDefineSymbolsIfNeeded();
        }

        /// <summary>
        /// �V���{�����`����
        /// </summary>
        private static void AddDefineSymbolsIfNeeded() {

            // ���݂̃r���h�^�[�Q�b�g���Ƃ̒�`�ς݂̃V���{�����擾
            var target = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            string defines = PlayerSettings.GetScriptingDefineSymbols(target);

            // �V���{���z����`�F�b�N���A����`�̂��̂�����Βǉ�
            foreach (var symbol in SYMBOL_ARRAY) {
                if (!defines.Contains(symbol)) {
                    defines += ";" + symbol;
                    Debug.Log($"Added define symbol: {symbol}");
                } 
            }
             
            // �V���{����ݒ�
            PlayerSettings.SetScriptingDefineSymbols(target, defines);
        }
    }
}
#endif
