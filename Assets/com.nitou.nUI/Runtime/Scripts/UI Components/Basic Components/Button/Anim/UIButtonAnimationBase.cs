using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {

    [RequireComponent(typeof(UIButton))]
    [DisallowMultipleComponent]
    public abstract class UIButtonAnimationBase : UIBehaviour {

        protected UIButton _button;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();
            _button = GetComponent<UIButton>();
            if (_button == null) return;

            // �o�C���h
            _button.OnDeselected.Subscribe(_ => OnDeselectAnimation()).AddTo(this);
            _button.OnSelected.Subscribe(_ => OnSelectAnimation()).AddTo(this);
            _button.OnSubmited.Subscribe(_ => OnClickAnimation()).AddTo(this);

            // ����������
            InitializeInternal();
        }

        protected override void OnDestroy() {
            // �I������
            DisposeInternal();

            base.OnDestroy();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// ����������
        /// </summary>
        protected virtual void InitializeInternal() { }

        /// <summary>
        /// ��I�����̒l��K�p����
        /// </summary>
        protected abstract void OnDeselectAnimation();

        /// <summary>
        /// �I�����̒l��K�p����
        /// </summary>
        protected abstract void OnSelectAnimation();

        /// <summary>
        /// �N���b�N���̃A�j���[�V����
        /// </summary>
        protected abstract void OnClickAnimation();

        /// <summary>
        /// �I������
        /// </summary>
        protected virtual void DisposeInternal() { }
    }
}
