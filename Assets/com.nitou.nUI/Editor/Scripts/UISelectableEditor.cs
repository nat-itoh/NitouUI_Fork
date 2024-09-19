#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [参考]
//  note: ボタンの派生クラス作ってインスペクタで設定する https://note.com/hikohiro/n/nc41855007f4e
//  Hatena: UnityのEditor拡張で「Script」フィールドを設置する方法 https://sokuhatiku.hateblo.jp/entry/2016/12/13/174513

namespace nitou.UI.Editor {
    using nitou.UI.Component;
    using nitou.EditorShared;

    [CustomEditor(typeof(UISelectable))]
    public class UISelectableEditor : UnityEditor.UI.SelectableEditor {

        public override void OnInspectorGUI() {

            // スクリプト参照
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), typeof(MonoScript), false);
            EditorGUI.EndDisabledGroup();

            // 基底クラスのインスペクタ
            base.OnInspectorGUI();

            // ----
            EditorUtil.GUI.HorizontalLine();

            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_cursor"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif