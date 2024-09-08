using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    public abstract class UISelectableTweenReactor<TTarget, TValue> : UISelectableReactorBase<TTarget, TValue> {

        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [Range(0.1f, 1f)]
        [SerializeField] protected float _duration = 0.2f;

        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [SerializeField] protected Ease _easing = Ease.OutCubic;

        // 内部処理用
        protected Sequence _tween;


        /// ----------------------------------------------------------------------------
        // Properity

        public abstract TValue DeselectedValue { get; set; }
        public abstract TValue SelectedValue { get; set; }


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void OnDisable() {
            base.OnDisable();
            _tween?.Kill();
            _tween = null;

            // 非選択時の値を適用
            SetValueImmediately(DeselectedValue);
        }

        protected override void OnDestroy() {
            base.OnDestroy();
            _tween?.Kill();
            _tween = null;
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitializeInternal() {
            SetValueImmediately(DeselectedValue);
        }

        /// <summary>
        /// 各オブジェクトに値を設定する
        /// </summary>
        protected override void ApplyValue(TValue value) {

            // ※再生中
            if (Application.isPlaying) {
                _tween?.Kill();

                _tween = DOTween.Sequence();
                _targetList.ForEach(
                    x => _tween.Join(GetTween(x, value).SetEase(_easing))
                );
                _tween.SetUpdate(true).SetLink(gameObject);
            }

            // ※エディタ編集中
            else {
                SetValueImmediately(value);
            }
        }

        /// <summary>
        /// 非選択時の値を適用する
        /// </summary>
        protected override void ApplyDeselectedValue() => ApplyValue(DeselectedValue);

        /// <summary>
        /// 選択時の値を適用する
        /// </summary>
        protected override void ApplySelectedValue() => ApplyValue(SelectedValue);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 各オブジェクトに値を即座に設定する
        /// </summary>
        protected abstract Tween GetTween(TTarget target, TValue value);

        /// <summary>
        /// 各オブジェクトに値を即座に設定する
        /// </summary>
        protected abstract void SetValueImmediately(TValue value);
    }
}
