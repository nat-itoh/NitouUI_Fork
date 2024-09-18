using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    [DisallowMultipleComponent]
    public sealed class StartSelection : MonoBehaviour{

        private UISelectable _selectable;

        public void Start() {
            _selectable = gameObject.GetComponent<UISelectable>();

            if (_selectable!=null && EventSystem.current != null) {
                _selectable.Select();
            }
        }

    }
}
