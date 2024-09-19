using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Shared;
using Sirenix.OdinInspector;

namespace nitou.UI{
    using EaseType = UnityScreenNavigator.Runtime.Core.Shared.EaseType;

    public class ButtonGroupTransitionAnimation : TransitionAnimationBehaviour {

        [SerializeField] Transform target;

        [Title("Tween settings")]
        [SerializeField] private float _delay;
        [SerializeField] private float _duration =1f;
        [SerializeField] private EaseType _easeType = EaseType.QuarticEaseOut;

        private Vector3 _beforePos;
        private Vector3 _afterPos;

        /// ----------------------------------------------------------------------------


        public override float Duration => _duration;


        /// ----------------------------------------------------------------------------
        // 

        public override void Setup() {
            // 
            _beforePos = target.position + Vector3.left * 200;
            _afterPos = target.position;

            //
        }

        public override void SetTime(float time) {
            time = Mathf.Max(0.0f, time - _delay);
            var progress = _duration <= 0.0f ? 1.0f : Mathf.Clamp01(time / _duration);

            // 各ボタンのイージング
            progress = Easings.Interpolate(progress, _easeType);
            var position = Vector3.Lerp(_beforePos, _afterPos, progress);

            target.position = position;
        }


    }
}
