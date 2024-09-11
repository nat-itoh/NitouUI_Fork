using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {


    public class UIShakeable : UISelectable, IUIShakeable {

        /// <summary>
        /// Setting that indicates one of four directions.
        /// </summary>
        public enum Direction {
            LeftToRight,
            RightToLeft,
            TopToBottom,
            BottomToTop,
        }

        public enum Axis {
            Horizontal = 0,
            Vertical = 1,
        }

        [SerializeField] private Direction _shakeDirection = Direction.LeftToRight;

        /// <summary>
        /// 水平、垂直のどちらの方向か
        /// </summary>
        Axis axis => _shakeDirection.IsAnyOf(Direction.LeftToRight, Direction.RightToLeft) ? Axis.Horizontal : Axis.Vertical;

        bool isReverse => _shakeDirection.IsAnyOf(Direction.RightToLeft, Direction.BottomToTop);

        // event
        protected Subject<Unit> _onMoveNextSubject = new();
        protected Subject<Unit> _onMovePreviousSubject = new();

        /// <summary>
        /// する時のイベント通知
        /// </summary>
        public IObservable<Unit> OnMoveNext => _onMoveNextSubject;

        /// <summary>
        /// する時のイベント通知
        /// </summary>
        public IObservable<Unit> OnMovePrevious => _onMovePreviousSubject;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();

            _disposables.Add(_onMoveNextSubject);
            _disposables.Add(_onMovePreviousSubject);
        }



        /// ----------------------------------------------------------------------------
        #region Move Event Handler

        public sealed override void OnMove(AxisEventData eventData) {
            if (!IsActive() || !IsInteractable()) {
                base.OnMove(eventData);
                return;
            }

            switch (eventData.moveDir) {
                case MoveDirection.Left when (axis is Axis.Horizontal && FindSelectableOnLeft() == null):
                    Process(isReverse);
                    break;
                case MoveDirection.Right when (axis is Axis.Horizontal && FindSelectableOnRight() == null):
                    Process(!isReverse);
                    break;
                case MoveDirection.Up when (axis is Axis.Vertical && FindSelectableOnUp() == null):
                    Process(isReverse);
                    break;
                case MoveDirection.Down when (axis is Axis.Vertical && FindSelectableOnDown() == null):
                    Process(!isReverse);
                    break;
                default:    // ※該当しなければ通常の移動イベント
                    base.OnMove(eventData);
                    break;
            }


            void Process(bool isNext) {
                if (isNext) ProcessMoveNext();
                else ProcessMovePrevious();
            }
        }

        /// <summary>
        /// See Selectable.FindSelectableOnLeft
        /// </summary>
        public sealed override Selectable FindSelectableOnLeft() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal) {
                return null;
            }
            return base.FindSelectableOnLeft();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnRight
        /// </summary>
        public sealed override Selectable FindSelectableOnRight() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Horizontal) {
                return null;
            }
            return base.FindSelectableOnRight();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnUp
        /// </summary>
        public sealed override Selectable FindSelectableOnUp() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical) {
                return null;
            }
            return base.FindSelectableOnUp();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnDown
        /// </summary>
        public sealed override Selectable FindSelectableOnDown() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == Axis.Vertical) {
                return null;
            }
            return base.FindSelectableOnDown();
        }

        #endregion


        /// ----------------------------------------------------------------------------


        protected virtual void ProcessMovePrevious() {
            _onMovePreviousSubject.OnNext(Unit.Default);

        }

        protected virtual void ProcessMoveNext() {
            _onMoveNextSubject.OnNext(Unit.Default);
        }
    }

}

