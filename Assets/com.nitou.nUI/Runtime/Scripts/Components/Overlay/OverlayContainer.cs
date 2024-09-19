using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Sirenix.OdinInspector;

namespace nitou.UI.Overlay {
    using nitou.UI.Component;

    /// <summary>
    /// �I�[�o�[���C���Ǘ�����
    /// </summary>
    public sealed class OverlayContainer : MonoBehaviour {

        [SerializeField, ReadOnly] private OverlayBase _current;

        private readonly Dictionary<string, OverlayBase> _instanceCacheByName = new ();

        internal OverlayBase Current => _current;
        public bool HasOverlay => _current != null;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �I�[�o�[���C��ǂݍ���
        /// </summary>
        public void Load<TOverlay>(string resourceKey) where TOverlay : OverlayBase {
            if (HasOverlay) {
                _current.DestroyGameObject();
            }

            // 
            var prefab = Resources.Load<TOverlay>(resourceKey);
            if (prefab == null) return;

            _current = Instantiate<TOverlay>(prefab, this.transform);
        }






        /// ----------------------------------------------------------------------------
        // Private Method



#if UNITY_EDITOR
        private void OnValidate() {

        }
#endif

    }

}
