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

            // バインド
            _uiSelectable.OnSelected.Subscribe(_ => ApplySelectedValue()).AddTo(this);
            _uiSelectable.OnDeselected.Subscribe(_ => ApplyDeselectedValue()).AddTo(this);
            
            // 初期化処理
            InitializeInternal();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected virtual void InitializeInternal() {}

        /// <summary>
        /// 各オブジェクトに値を設定する
        /// </summary>
        protected abstract void ApplyValue(TValue value);

        /// <summary>
        /// 非選択時の値を適用する
        /// </summary>
        protected abstract void ApplyDeselectedValue();

        /// <summary>
        /// 選択時の値を適用する
        /// </summary>
        protected abstract void ApplySelectedValue();
    }
}
