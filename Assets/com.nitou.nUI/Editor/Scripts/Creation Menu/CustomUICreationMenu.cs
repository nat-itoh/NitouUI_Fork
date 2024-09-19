#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [参考]
//  コガネブログ: MenuItemでHierarchyのCreateメニューを自作する時のお作法 https://baba-s.hatenablog.com/entry/2022/09/10/192926_2

namespace nitou.UI.EditorScripts {

    /// <summary>
    /// UIのデフォルトGameObject生成に関するメニューコマンド
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
        /// モデルのインスタンスを生成する
        /// </summary>
        private static void CreateGameObject(MenuCommand menuCommand, CustomUIType type) {

            if (CustomUIDatabase.Instance.TryGetPrefab(type, out var meshObj)) {

                // オブジェクト生成
                var gameObject = GameObject.Instantiate(meshObj);
                gameObject.name = type.ToString();

                // 
                GameObjectUtility.SetParentAndAlign(gameObject, menuCommand.context as GameObject);

                // Undo設定
                Undo.RegisterCreatedObjectUndo(gameObject, gameObject.name);

                // 選択状態に設定
                Selection.activeObject = gameObject;
            }
        }
    }

}
#endif