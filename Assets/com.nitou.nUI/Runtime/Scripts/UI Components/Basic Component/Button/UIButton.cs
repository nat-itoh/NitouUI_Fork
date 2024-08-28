using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;

namespace nitou.UI.Component {

    /// <summary>
    /// ��{�@�\�݂̂̓Ǝ��{�^��UI�i���N���b�N�ƃT�u�~�b�g�͓���Ƃ��Ĉ����j
    /// </summary>
    [AddComponentMenu(
        menuName: UIComponentMenu.Prefix.UIComponent + "UI Button"
    )]
    public class UIButton : UISelectable, IUISubmitable, IUICancelable,
        ISubmitHandler, ICancelHandler, IPointerClickHandler {

        protected Subject<Unit> _onSubmitSubject = new();
        protected Subject<Unit> _onCancelSubject = new();

        private float _coolDown = 0f;


        /// ----------------------------------------------------------------------------
        // Properity

        /// <summary>
        /// ������͂��ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSubmited => _onSubmitSubject;

        /// <summary>
        /// �L�����Z�����͂��ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnCanceled => _onCancelSubject;

        /// <summary>
        /// ���b�N��Ԃ��ǂ���
        /// </summary>
        public bool IsLocked { get; set; } = false;


        /// ----------------------------------------------------------------------------
        // Public MonoBehaviour

        protected override void OnDestroy() {
            base.OnDestroy();
            _onSubmitSubject.Dispose();
            _onCancelSubject.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Interface Method

        /// <summary>
        /// ������͂��ꂽ�Ƃ��̏���
        /// </summary>
        public virtual void OnSubmit(BaseEventData eventData) {
            Press();

            DoStateTransition(SelectionState.Pressed, false);
            StartCoroutine(OnFinishSubmit());
        }

        /// <summary>
        /// ������͂��ꂽ�Ƃ��̏���
        /// </summary>
        public virtual void OnCancel(BaseEventData eventData) {

            _onCancelSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// �N���b�N���ꂽ�Ƃ��̏���
        /// </summary>
        public virtual void OnPointerClick(PointerEventData eventData) {
            // ���N���b�N�̂�
            if (eventData.button != PointerEventData.InputButton.Left) return;

            Press();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        protected void Press() {
            if (!IsActive() || !IsInteractable() || IsLocked) return;

            UISystemProfilerApi.AddMarker("Button.onClick", this);
            _onSubmitSubject.OnNext(Unit.Default);
        }

        private IEnumerator OnFinishSubmit() {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;

            while (elapsedTime < fadeTime) {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            base.DoStateTransition(currentSelectionState, false);
        }


        /// ----------------------------------------------------------------------------
        // Editor
#if UNITY_EDITOR
        protected override void Reset() {
            base.Reset();
        }
#endif
    }
}