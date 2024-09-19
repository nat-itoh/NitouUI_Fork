#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  �R�K�l�u���O: MenuItem��Hierarchy��Create���j���[�����삷�鎞�̂���@ https://baba-s.hatenablog.com/entry/2022/09/10/192926_2

namespace nitou.UI.EditorScripts {

    /// <summary>
    /// UI�̃f�t�H���gGameObject�����Ɋւ��郁�j���[�R�}���h
    /// </summary>
    public static class CustomUICreationMenu {

        private const string CREATE_UI_COMPONENT = "GameObject/UI/Custom/";


        /// ----------------------------------------------------------------------------
        // Public Method 

        [MenuItem(CREATE_UI_COMPONENT + "Button", priority = -1)]
        public static void Create_Button(MenuCommand menuCommand) => CreateGameObject(menuCommand, CustomUIType.Button);

        [MenuItem(CREATE_UI_COMPONENT + "Icon Button", priority = -1)]
        public static void Create_IconButton(MenuCommand menuCommand) => CreateGameObject(menuCommand, CustomUIType.IconButton);

        [MenuItem(CREATE_UI_COMPONENT + "Slider", priority = -1)]
        public static void Create_Slider(MenuCommand menuCommand) => CreateGameObject(menuCommand, CustomUIType.Slider);

        // ---- 

        [MenuItem(CREATE_UI_COMPONENT + "Score View")]
        public static void Create_ScoreView(MenuCommand menuCommand) => CreateGameObject(menuCommand, CustomUIType.ScoreView);


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// ���f���̃C���X�^���X�𐶐�����
        /// </summary>
        private static void CreateGameObject(MenuCommand menuCommand, CustomUIType type) {

            if (CustomUIDatabase.Instance.TryGetPrefab(type, out var meshObj)) {

                // �I�u�W�F�N�g����
                var gameObject = GameObject.Instantiate(meshObj);
                gameObject.name = type.ToString();

                // 
                GameObjectUtility.SetParentAndAlign(gameObject, menuCommand.context as GameObject);

                // Undo�ݒ�
                Undo.RegisterCreatedObjectUndo(gameObject, gameObject.name);

                // �I����Ԃɐݒ�
                Selection.activeObject = gameObject;
            }
        }
    }

}
#endif