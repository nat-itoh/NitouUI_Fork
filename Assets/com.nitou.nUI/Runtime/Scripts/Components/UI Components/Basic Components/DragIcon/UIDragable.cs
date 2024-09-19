using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {

    /// <summary>
    /// �h���b�O�@�\��ǉ�����UI
    /// </summary>
    [DisallowMultipleComponent]
    public class UIDragable : UIBehaviour {

        private ObservableEventTrigger _trigger;
        private ObservableEventTrigger Trigger => _trigger ?? (_trigger = this.gameObject.AddComponent<ObservableEventTrigger>());

        private readonly Subject<PointerEventData> _onBeginDragSubject = new();
        private readonly Subject<PointerEventData> _onEndDragSubject = new();
                
        public IObservable<PointerEventData> BeginDragAsObservable => _onBeginDragSubject;
        public IObservable<PointerEventData> EndDragAsObservable => _onEndDragSubject;

        /// <summary>
        /// �h���b�O�����ǂ���
        /// </summary>
        public bool IsDraging { get; private set; }


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake(){
            base.Awake();

            // Drag�C�x���g�̓o�^
            Trigger.OnDragAsObservable().Subscribe(DragProcess).AddTo(this);
            Trigger.OnBeginDragAsObservable().Subscribe(BeginDragProcess).AddTo(this);
            Trigger.OnEndDragAsObservable().Subscribe(EndDragProcess).AddTo(this);
        }

        protected override void OnDestroy() {
            _onBeginDragSubject?.Dispose();
            _onEndDragSubject?.Dispose();
            
            base.OnDestroy();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// Drag���̏���
        /// </summary>
        private void DragProcess(PointerEventData eventData) {
            OnDrag(eventData);
        }

        /// <summary>
        /// Drag�J�n���̏���
        /// </summary>
        private void BeginDragProcess(PointerEventData eventData) {
            OnBeginDrag(eventData);
            IsDraging = true;
            _onBeginDragSubject.OnNext(eventData);
        }

        /// <summary>
        /// Drag�I�����̏���
        /// </summary>
        private void EndDragProcess(PointerEventData eventData) {
            OnEndDrag(eventData);
            IsDraging = false;
            _onEndDragSubject.OnNext(eventData);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method 

        protected virtual void OnDrag(PointerEventData eventData) {
            ApplyPointerPosition(eventData);
        }

        protected virtual void OnBeginDrag(PointerEventData eventData) { }
        protected virtual void OnEndDrag(PointerEventData eventData) { }
        

        protected void ApplyPointerPosition(PointerEventData eventData) {
            transform.position = eventData.position;
        }
    }

}