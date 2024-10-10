#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [参考]
//  note: ボタンの派生クラス作ってインスペクタで設定する https://note.com/hikohiro/n/nc41855007f4e

namespace nitou.UI.Editor {
    using nitou.UI.Component;
    using nitou.EditorShared;

    [CustomEditor(typeof(UIButton))]
    public class UIButtonEditor : UnityEditor.UI.SelectableEditor {

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            // ----
            EditorGUILayout.Space();
            EditorUtil.GUI.HorizontalLine();

            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_cursor"));

            serializedObject.ApplyModifiedProperties();
        }


    }

}

#endif