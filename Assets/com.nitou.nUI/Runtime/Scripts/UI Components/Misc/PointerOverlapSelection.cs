using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    [DisallowMultipleComponent]
    public class PointerOverlapSelection : MonoBehaviour, 
        IPointerEnterHandler, IPointerExitHandler{

        private UISelectable _selectable;


        private void Awake() {
            _selectable = gameObject.GetComponent<UISelectable>();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
            if (_selectable is null) return;

            EventSystem.current.SetSelectedGameObject(_selectable.gameObject);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        }
    }
}
