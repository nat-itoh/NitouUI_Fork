using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    /// <summary>
    /// �|�C���^�[���I�[�o�[���b�v�������ɗv�f��I������R���|�[�l���g
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PointerOverlapSelection : MonoBehaviour, 
        IPointerEnterHandler, IPointerExitHandler{

        private Selectable _selectable;


        private void Awake() {
            _selectable = gameObject.GetComponent<Selectable>();
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
            if (_selectable is null) return;

            EventSystem.current.SetSelectedGameObject(_selectable.gameObject);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
        }
    }
}
