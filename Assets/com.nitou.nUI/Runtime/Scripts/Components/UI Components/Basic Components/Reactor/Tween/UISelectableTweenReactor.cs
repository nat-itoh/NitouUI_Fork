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

        // ���������p
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

            // ��I�����̒l��K�p
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
        /// ����������
        /// </summary>
        protected override void InitializeInternal() {
            SetValueImmediately(DeselectedValue);
        }

        /// <summary>
        /// �e�I�u�W�F�N�g�ɒl��ݒ肷��
        /// </summary>
        protected override void ApplyValue(TValue value) {

            // ���Đ���
            if (Application.isPlaying) {
                _tween?.Kill();

                _tween = DOTween.Sequence();
                _targetList.ForEach(
                    x => _tween.Join(GetTween(x, value).SetEase(_easing))
                );
                _tween.SetUpdate(true).SetLink(gameObject);
            }

            // ���G�f�B�^�ҏW��
            else {
                SetValueImmediately(value);
            }
        }

        /// <summary>
        /// ��I�����̒l��K�p����
        /// </summary>
        protected override void ApplyDeselectedValue() => ApplyValue(DeselectedValue);

        /// <summary>
        /// �I�����̒l��K�p����
        /// </summary>
        protected override void ApplySelectedValue() => ApplyValue(SelectedValue);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �e�I�u�W�F�N�g�ɒl�𑦍��ɐݒ肷��
        /// </summary>
        protected abstract Tween GetTween(TTarget target, TValue value);

        /// <summary>
        /// �e�I�u�W�F�N�g�ɒl�𑦍��ɐݒ肷��
        /// </summary>
        protected abstract void SetValueImmediately(TValue value);
    }
}
