using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

namespace nitou.UI.Component{

    public abstract class UISelectableReactorBase<TTarget,TValue> : UIBehaviour{

        public class GroupKey {
            public const string REACT_OBJECTS = "React Objects";
            public const string TWEEN_PARAM = "Tween Parameters";
        }

        protected IUISelectable _uiSelectable;


        /// ----------------------------------------------------------------------------
        // Field

        [TitleGroup(GroupKey.REACT_OBJECTS), Indent]
        [SerializeField] protected List<TTarget> _targetList = new();


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            base.Awake();
            _uiSelectable = GetComponent<IUISelectable>();
            if (_uiSelectable == null) return;

            // �o�C���h
            _uiSelectable.OnSelected.Subscribe(_ => ApplySelectedValue()).AddTo(this);
            _uiSelectable.OnDeselected.Subscribe(_ => ApplyDeselectedValue()).AddTo(this);
            
            // ����������
            InitializeInternal();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// ����������
        /// </summary>
        protected virtual void InitializeInternal() {}

        /// <summary>
        /// �e�I�u�W�F�N�g�ɒl��ݒ肷��
        /// </summary>
        protected abstract void ApplyValue(TValue value);

        /// <summary>
        /// ��I�����̒l��K�p����
        /// </summary>
        protected abstract void ApplyDeselectedValue();

        /// <summary>
        /// �I�����̒l��K�p����
        /// </summary>
        protected abstract void ApplySelectedValue();
    }
}
