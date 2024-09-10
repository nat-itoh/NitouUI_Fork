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
            /// <summary>
            /// From the left to the right
            /// </summary>
            LeftToRight,

            /// <summary>
            /// From the right to the left
            /// </summary>
            RightToLeft,

            /// <summary>
            /// From the bottom to the top.
            /// </summary>
            BottomToTop,

            /// <summary>
            /// From the top to the bottom.
            /// </summary>
            TopToBottom,
        }

        public enum Axis {
            Horizontal = 0,
            Vertical = 1,
        }

        [SerializeField] private Direction _shakeDirection = Direction.LeftToRight;;

        Axis axis => (_shakeDirection == Direction.LeftToRight || _shakeDirection == Direction.RightToLeft) ? Axis.Horizontal : Axis.Vertical;
        bool reverseValue => _shakeDirection == Direction.RightToLeft || _shakeDirection == Direction.TopToBottom;



        // event
        protected Subject<Unit> _onMoveNextSubject = new();
        protected Subject<Unit> _onMovePreviousSubject = new();

        /// <summary>
        /// 
        /// </summary>
        public IObservable<Unit> OnMoveNext => _onMoveNextSubject;

        /// <summary>
        /// 
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

        public override void OnMove(AxisEventData eventData) {
            if (!IsActive() || !IsInteractable()) {
                base.OnMove(eventData);
                return;
            }

            // Shake
            switch (_shakeDirection, eventData.moveDir) {
                // Previous
                case (Axis.Horizontal, MoveDirection.Left):
                case (Axis.Vertical, MoveDirection.Up): {
                        ProcessMovePrevious();
                        return;
                    }
                // Next
                case (Axis.Horizontal, MoveDirection.Right):
                case (Axis.Vertical, MoveDirection.Down): {
                        ProcessMoveNext();
                        return;
                    }
            }

            base.OnMove(eventData);
        }


        /// <summary>
        /// See Selectable.FindSelectableOnLeft
        /// </summary>
        public override Selectable FindSelectableOnLeft() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == nitou.Axis.Horizontal)
                return null;
            return base.FindSelectableOnLeft();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnRight
        /// </summary>
        public override Selectable FindSelectableOnRight() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == nitou.Axis.Horizontal)
                return null;
            return base.FindSelectableOnRight();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnUp
        /// </summary>
        public override Selectable FindSelectableOnUp() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == nitou.Axis.Vertical)
                return null;
            return base.FindSelectableOnUp();
        }

        /// <summary>
        /// See Selectable.FindSelectableOnDown
        /// </summary>
        public override Selectable FindSelectableOnDown() {
            if (navigation.mode == Navigation.Mode.Automatic && axis == nitou.Axis.Vertical)
                return null;
            return base.FindSelectableOnDown();
        }

        #endregion


        protected virtual void ProcessMovePrevious() {
            _onMovePreviousSubject.OnNext(Unit.Default);

        }

        protected virtual void ProcessMoveNext() {
            _onMoveNextSubject.OnNext(Unit.Default);
        }
    }

}