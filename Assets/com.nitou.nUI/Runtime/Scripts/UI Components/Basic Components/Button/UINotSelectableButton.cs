using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {

    /// <summary>
    /// �I����ԂɂȂ�Ȃ��Ǝ��{�^��UI
    /// </summary>
    [AddComponentMenu(
         menuName: UIComponentMenu.Prefix.UIComponent + "UI NotSelectable Button"
    )]
    public class UINotSelectableButton : UIBehaviour, IUISubmitable, 
        IPointerClickHandler {

        private Subject<Unit> _onClickSubject = new();

        /// <summary>
        /// �N���b�N���ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSubmited => _onClickSubject;


        /// ----------------------------------------------------------------------------
        // Public MonoBehaviour

        protected override void OnDestroy() {
            base.OnDestroy();
            _onClickSubject.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) {
            // ���N���b�N�̂�
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Press();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        public void Press() {
            if (!IsActive()) return;

            UISystemProfilerApi.AddMarker("Button.onClick", this);
            _onClickSubject.OnNext(Unit.Default);
        }
    }

}