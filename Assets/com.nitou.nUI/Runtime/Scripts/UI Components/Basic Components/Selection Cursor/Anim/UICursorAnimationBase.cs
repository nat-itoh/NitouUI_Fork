using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nitou.UI.Component{

    [RequireComponent(typeof(UICursor))]
    [DisallowMultipleComponent]
    public abstract class UICursorAnimationBase : UIBehaviour {

        protected UICursor _cursor;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();
            _cursor = GetComponent<UICursor>();
            if (_cursor == null) return;

            // �o�C���h
            _cursor.OnEnabled.Subscribe(_ => OnEnableAnimation()).AddTo(this);
            _cursor.OnDisabled.Subscribe(_ => OnDisableAnimation()).AddTo(this);

            // ����������
            InitializeInternal();
        }

        protected override void OnDestroy() {
            base.OnDestroy();

            // �I������
            DisposeInternal();
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
        protected abstract void OnEnableAnimation();

        /// <summary>
        /// �I�����̒l��K�p����
        /// </summary>
        protected abstract void OnDisableAnimation();

        /// <summary>
        /// �I������
        /// </summary>
        protected virtual void DisposeInternal() { }
    }
}
