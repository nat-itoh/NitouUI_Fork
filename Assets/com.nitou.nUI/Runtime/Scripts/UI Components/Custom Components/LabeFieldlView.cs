using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace nitou.UI.Component{

    /// <summary>
    /// �V���v���ȃ��x���Ɩ{��������View
    /// </summary>
    [DisallowMultipleComponent]
    public class LabeFieldlView : MonoBehaviour{

        [SerializeField, Indent] protected TextMeshProUGUI _labelText;
        [SerializeField, Indent] protected TextMeshProUGUI _valueText;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// ���x����ݒ肷��
        /// </summary>
        public void SetLabel(string label) {
            if (label == null) return;
            _labelText.text = label;
        }

        /// <summary>
        /// �{����ݒ肷��
        /// </summary>
        public void SetValue(string value) {
            if (value == null) return;
            _valueText.text = value;
        }

        public void SetDefault() {
            SetLabel("label");
            SetValue("value");
        }
    }
}
