using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// 独自UIにフィルイベントを登録するコンポーネント
    /// </summary>
    public class UISelectableFillReactor : UISelectableTweenReactor<Image, float> {

        /// ----------------------------------------------------------------------------
        // Field

        /// <summary>
        /// 非選択状態のフィル値
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [Range(0, 1)]
        [InlineButton("ApplyDeselectedValue", SdfIconType.Droplet, label: " ")]
        [SerializeField] float _deselectedValue = 0f;

        /// <summary>
        /// 選択状態のフィル値
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [Range(0, 1)]
        [InlineButton("ApplySelectedValue", SdfIconType.Droplet, label: " ")]
        [SerializeField] float _selectedValue = 1f;


        /// ----------------------------------------------------------------------------
        // Properity

        public override float DeselectedValue {
            get => _deselectedValue;
            set => _deselectedValue = Mathf.Clamp01(value);
        }

        public override float SelectedValue {
            get => _selectedValue;
            set => _selectedValue = Mathf.Clamp01(value);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitializeInternal() {
            foreach(var image in _targetList) {
                image.type = Image.Type.Filled;
                image.fillAmount = DeselectedValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override Tween GetTween(Image target, float value) {
            return target.DOFillAmount(value, _duration);
        }

        /// <summary>
        /// 全てのターゲットを非選択時の演出状態にする
        /// </summary>
        protected override void SetValueImmediately( float value) {
            _targetList.ForEach(x => x.fillAmount = value);
        }
    }
}
