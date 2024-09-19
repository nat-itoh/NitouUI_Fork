using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// まだ汎用性のある仕様が分からないため，とりあえずUI側では状態（インデックス）を持たない実装にする
    /// </summary>
    public class UIIndexSelector : UISelectable, IUIValueChangeable<int> {

        [SerializeField] UINotSelectableButton _previousButton;
        [SerializeField] UINotSelectableButton _nextButton;

        [SerializeField] TextMeshProUGUI _labelText;

        private readonly Subject<int> _onValueChangeSubject = new();


        /// ----------------------------------------------------------------------------
        // Properity

        /// <summary>
        /// 値が変化した時のイベント通知
        /// </summary>
        public IObservable<int> OnValueChanged => _onValueChangeSubject;

        /// <summary>
        /// 現在のインデックス
        /// </summary>
        public int CurrentIndex { get; private set; } = -1;

        /// <summary>
        /// 要素数
        /// </summary>
        public int MaxNum { get; private set; } = 5;


        /// ----------------------------------------------------------------------------
        // Public MonoBehaviour

        protected override void OnDestroy() {
            base.OnDestroy();

            _onValueChangeSubject.Dispose();
        }

        protected override void Awake() {
            base.Awake();

            SetIndex(0);
            _previousButton.OnSubmited.Subscribe(_ => OnMoveButtonClicked(CurrentIndex - 1)).AddTo(this);
            _nextButton.OnSubmited.Subscribe(_ => OnMoveButtonClicked(CurrentIndex + 1)).AddTo(this);
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        /// <summary>
        /// 移動入力されたときの処理
        /// </summary>
        public override void OnMove(AxisEventData eventData) {

            switch (eventData.moveDir) {
                // 
                case MoveDirection.Left:
                    if (CanMovePrevious() && _previousButton != null) {
                        Debug_.Log("UI Selector - Left!");
                        _previousButton.Press();
                    }
                    break;
                case MoveDirection.Right:
                    if (CanMoveNext() && _nextButton != null) {
                        Debug_.Log("UI Selector - Right!");
                        _nextButton.Press();
                    }
                    break;

                // Navigation
                case MoveDirection.Up:
                    Navigate(eventData, FindSelectableOnUp());
                    break;
                case MoveDirection.Down:
                    Navigate(eventData, FindSelectableOnDown());
                    break;
            }

            _onMoveSubject.OnNext(eventData.moveDir);
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        public void SetIndex(int index) {
            if (!index.IsInRange(0, MaxNum) || index == CurrentIndex) return;

            CurrentIndex = index;
            _onValueChangeSubject.OnNext(CurrentIndex);

            _labelText.text = $"index : {CurrentIndex}";
        }

        public bool CanMovePrevious() => (CurrentIndex - 1) >= 0;
        public bool CanMoveNext() => (CurrentIndex + 1) < MaxNum;


        /// ----------------------------------------------------------------------------
        // Private Method

        private void Navigate(AxisEventData eventData, Selectable sel) {
            if (sel != null && sel.IsActive())
                eventData.selectedObject = sel.gameObject;
        }

        private void OnMoveButtonClicked(int index) {
            SetIndex(index);
            this.Select();
        }
    }
}
