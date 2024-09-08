using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {

    /// <summary>
    /// 選択状態にならない独自ボタンUI
    /// </summary>
    [AddComponentMenu(
         menuName: UIComponentMenu.Prefix.UIComponent + "UI NotSelectable Button"
    )]
    public class UINotSelectableButton : UIBehaviour, IUISubmitable, 
        IPointerClickHandler {

        private Subject<Unit> _onClickSubject = new();

        /// <summary>
        /// クリックされた時のイベント通知
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
            // 左クリックのみ
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