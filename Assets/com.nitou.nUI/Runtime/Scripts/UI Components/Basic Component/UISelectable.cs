using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// Selectable�ɓƎ��@�\��ǉ�������{�R���|�[�l���g
    /// </summary>
    public class UISelectable : Selectable, IUISelectable, IUIMoveable {

        protected Subject<Unit> _onSelectSubject = new();
        protected Subject<Unit> _onDeselectSubject = new();
        protected Subject<MoveDirection> _onMoveSubject = new();


        [SerializeField] protected UICursor _cursor;


        /// ----------------------------------------------------------------------------
        // Properity

        /// <summary>
        /// �I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSelected => _onSelectSubject;

        /// <summary>
        /// ��I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnDeselected => _onDeselectSubject;

        /// <summary>
        /// �ړ����͂����������̃C�x���g�ʒm
        /// </summary>
        public IObservable<MoveDirection> OnMoved => _onMoveSubject;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();
            SetCursorActivation(false);
        }

        protected override void OnDestroy() {
            base.OnDestroy();

            _onSelectSubject.Dispose();
            _onDeselectSubject.Dispose();
            _onMoveSubject.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        /// <summary>
        /// �I�����ꂽ�Ƃ��̏���
        /// </summary>
        public override void OnSelect(BaseEventData eventData) {
            base.OnSelect(eventData);

            _onSelectSubject.OnNext(Unit.Default);
            SetCursorActivation(true);
        }

        /// <summary>
        /// �I�����ꂽ�Ƃ��̏���
        /// </summary>
        public override void OnDeselect(BaseEventData eventData) {
            base.OnDeselect(eventData);

            _onDeselectSubject.OnNext(Unit.Default);
            SetCursorActivation(false);
        }

        /// <summary>
        /// �ړ����͂��ꂽ�Ƃ��̏���
        /// </summary>
        public override void OnMove(AxisEventData eventData) {

            base.OnMove(eventData);
            _onMoveSubject.OnNext(eventData.moveDir);
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        public override void Select() {
            // �������Ƀt�B���^�����O��ǉ����邩��

            base.Select();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �I���J�[�\���̃A�N�e�B�u��Ԃ�ݒ肷�� 
        /// </summary>
        protected void SetCursorActivation(bool value) {
            if (_cursor == null) return;

            _cursor.enabled = value;
            _cursor.gameObject.SetActive(value);
        }


        /// ----------------------------------------------------------------------------
        // Editor
#if UNITY_EDITOR
        protected override void Reset() {
            this.transition = Transition.None;
        }
#endif
    }
}
