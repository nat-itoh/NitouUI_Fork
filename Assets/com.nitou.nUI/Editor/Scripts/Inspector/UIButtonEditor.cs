#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  note: �{�^���̔h���N���X����ăC���X�y�N�^�Őݒ肷�� https://note.com/hikohiro/n/nc41855007f4e

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