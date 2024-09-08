using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// 独自UIにスケールイベントを登録するコンポーネント
    /// </summary>
    public class UISelectableScaleReactor : UISelectableTweenReactor<Transform, Vector3>{

        /// ----------------------------------------------------------------------------
        // Field 

        /// <summary>
        /// 非選択状態のスケール値
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplyDeselectedValue", SdfIconType.Droplet, label: " ")]
        [SerializeField] Vector3 _deselectedValue = Vector3.right;

        /// <summary>
        /// 選択状態のスケール値
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplySelectedValue", SdfIconType.Droplet, label: " ")]
        [SerializeField] Vector3 _selectedValue = Vector3.one;


        /// ----------------------------------------------------------------------------
        // Properity

        public override Vector3 DeselectedValue {
            get => _deselectedValue;
            set => _deselectedValue = value;
        }

        public override Vector3 SelectedValue {
            get => _selectedValue;
            set => _selectedValue = value;
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 
        /// </summary>
        protected override Tween GetTween(Transform target, Vector3 value) {
            return target.DOScale(value, _duration);
        }

        /// <summary>
        /// 全てのターゲットを非選択時の演出状態にする
        /// </summary>
        protected override void SetValueImmediately(Vector3 value) {
            _targetList.ForEach(x => x.localScale = value);
        }
    }

}