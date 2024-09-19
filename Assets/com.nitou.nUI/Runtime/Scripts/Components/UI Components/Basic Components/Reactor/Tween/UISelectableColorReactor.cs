using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// 独自UIにカラーイベントを登録するコンポーネント
    /// </summary>
    public class UISelectableColorReactor : UISelectableTweenReactor<Graphic, Color> {

        /// ----------------------------------------------------------------------------
        // Field

        /// <summary>
        /// 非選択状態のカラー
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplyDeselectedValue", SdfIconType.Droplet, label: " ")]
        [OdinIgnore]
        [SerializeField] Color _deselectedColor = Colors.LightGray;

        /// <summary>
        /// 選択状態のカラー
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplySelectedValue", SdfIconType.Droplet, label: " ")]
        [OdinIgnore]
        [SerializeField] Color _selectedColor = Colors.LightGray;


        /// ----------------------------------------------------------------------------
        // Properity

        public override Color DeselectedValue {
            get => _deselectedColor;
            set => _deselectedColor = value;
        }

        public override Color SelectedValue {
            get => _selectedColor;
            set => _selectedColor = value;
        }

        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 
        /// </summary>
        protected override Tween GetTween(Graphic target, Color value) {
            return target.DOColor(value, _duration);
        }

        /// <summary>
        /// 全てのターゲットを非選択時の演出状態にする
        /// </summary>
        protected override void SetValueImmediately(Color value) {
            _targetList.ForEach(x => x.color = value);
        }

    }

}