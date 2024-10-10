#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  note: �{�^���̔h���N���X����ăC���X�y�N�^�Őݒ肷�� https://note.com/hikohiro/n/nc41855007f4e
//  Hatena: Unity��Editor�g���ŁuScript�v�t�B�[���h��ݒu������@ https://sokuhatiku.hateblo.jp/entry/2016/12/13/174513

namespace nitou.UI.Editor {
    using nitou.UI.Component;
    using nitou.EditorShared;

    [CustomEditor(typeof(UISelectable))]
    public class UISelectableEditor : UnityEditor.UI.SelectableEditor {

        public override void OnInspectorGUI() {

            // �X�N���v�g�Q��
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), typeof(MonoScript), false);
            EditorGUI.EndDisabledGroup();

            // ���N���X�̃C���X�y�N�^
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