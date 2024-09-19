#if UNITY_EDITOR
using UnityEngine;
using Sirenix.OdinInspector;

namespace nitou.UI.EditorScripts {
    using nitou.DesignPattern;

    /// <summary>
    /// ���f���̎��
    /// </summary>
    public enum CustomUIType {

        // UI Component
        Button,
        IconButton,
        Slider,

        // UI View
        ScoreView,
    }

    /// <summary>
    /// �v���~�e�B�u�`��̃��b�V���v���n�u���Ǘ�����f�[�^�x�[�X
    /// �i��RunTime�ł̎g�p�͑z�肵�Ă��Ȃ��j
    /// </summary>
    [CreateAssetMenu(
        fileName = "CustomUIList",
        menuName = AssetMenu.Prefix.ScriptableObject + "Editor/Custom UI List")
    ]
    public class CustomUIDatabase : SingletonScriptableObject<CustomUIDatabase> {

        /// ----------------------------------------------------------------------------
        // Field

        [FoldoutGroup("UI Component"), Indent]
        [LabelText("Button")]
        [PreviewField, AssetsOnly]
        [SerializeField] GameObject _button;

        [FoldoutGroup("UI Component"), Indent]
        [LabelText("Icon Button")]
        [PreviewField, AssetsOnly]
        [SerializeField] GameObject _iconButton;

        [FoldoutGroup("UI Component"), Indent]
        [LabelText("Slider")]
        [PreviewField, AssetsOnly]
        [SerializeField] GameObject _slider;

        // ---

        [FoldoutGroup("UI View"), Indent]
        [LabelText("Score View")]
        [PreviewField, AssetsOnly]
        [SerializeField] GameObject _scoreView;

        [FoldoutGroup("UI View"), Indent]
        [LabelText("Timer View")]
        [PreviewField, AssetsOnly]
        [SerializeField] GameObject _timerView;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �w�肵����ނ�UI���擾����
        /// </summary>
        public bool TryGetPrefab(CustomUIType type, out GameObject uiPrefab) {
            uiPrefab = type switch {

                // Lowpoly Meshs
                CustomUIType.Button => _button,
                CustomUIType.IconButton => _iconButton,
                CustomUIType.Slider => _slider,

                // Reverse Meshs
                CustomUIType.ScoreView => _scoreView,
                _ => null
            };

            return uiPrefab != null;
        }
    }
}
#endif