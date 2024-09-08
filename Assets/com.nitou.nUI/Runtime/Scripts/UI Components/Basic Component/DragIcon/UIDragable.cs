using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {

    public abstract class UIDragable : UIBehaviour {

        private ObservableEventTrigger _trigger;
        private ObservableEventTrigger Trigger => _trigger ?? (_trigger = this.gameObject.AddComponent<ObservableEventTrigger>());

        private Subject<PointerEventData> _onBeginDragSubject = new();
        private Subject<PointerEventData> _onEndDragSubject = new();

        public IObservable<PointerEventData> BeginDragAsObservable => _onBeginDragSubject;
        public IObservable<PointerEventData> EndDragAsObservable => _onEndDragSubject;

        /// <summary>
        /// ドラッグ中かどうか
        /// </summary>
        public bool IsDraging { get; private set; }


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake(){
            base.Awake();

            // Dragイベントの登録
            Trigger.OnDragAsObservable().Subscribe(DragProcess).AddTo(this);
            Trigger.OnBeginDragAsObservable().Subscribe(BeginDragProcess).AddTo(this);
            Trigger.OnEndDragAsObservable().Subscribe(EndDragProcess).AddTo(this);
        }

        protected override void OnDestroy() {
            base.OnDestroy();

            _onBeginDragSubject.Dispose();
            _onEndDragSubject.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        protected abstract void OnDrag(PointerEventData eventData);
        protected virtual void OnBeginDrag(PointerEventData eventData) { }
        protected virtual void OnEndDrag(PointerEventData eventData) { }
                

        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// Drag中の処理
        /// </summary>
        private void DragProcess(PointerEventData eventData) {
            OnDrag(eventData);
        }

        /// <summary>
        /// Drag開始時の処理
        /// </summary>
        private void BeginDragProcess(PointerEventData eventData) {
            OnBeginDrag(eventData);
            IsDraging = true;
            _onBeginDragSubject.OnNext(eventData);
        }

        /// <summary>
        /// Drag終了時の処理
        /// </summary>
        private void EndDragProcess(PointerEventData eventData) {
            OnEndDrag(eventData);
            IsDraging = false;
            _onEndDragSubject.OnNext(eventData);
        }

    }

}