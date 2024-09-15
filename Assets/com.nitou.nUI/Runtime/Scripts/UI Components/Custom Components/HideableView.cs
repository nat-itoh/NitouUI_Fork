using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// 表示・非表示の切り替えが可能なUI
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    [DisallowMultipleComponent]
    public abstract class HideableView : UIBehaviour, IHideableView {

        [TitleGroup(IKey.COMPONENT)]
        [SerializeField, Indent] protected CanvasGroup _canvasGroup;

        [TitleGroup(IKey.SETTINGS)]
        [SerializeField, Indent] private bool _hideOnAwake = false;

        protected Tweener _mainTween;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void Awake() {
            if (_canvasGroup == null) {
                _canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
            }

            // 非表示状態
            if (_hideOnAwake) {
                DOHide(0f);
            }
        }

        protected override void OnDestroy() {
            _mainTween?.Kill();
        }

#if UNITY_EDITOR
        protected override void OnValidate() {
            if (_canvasGroup == null) _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        }
#endif


        /// ----------------------------------------------------------------------------
        // Public Method (表示・非表示)

        public virtual Tweener DOShow(float duration = 0.2f) {
            gameObject.SetActive(true);

            // 
            _mainTween = _canvasGroup.DOFadeIn(duration)
                .IgnoreTimeScale().SetLink(gameObject);
            return _mainTween;
        }

        public virtual Tweener DOHide(float duration = 0.2f) {

            // 
            _mainTween = _canvasGroup.DOFadeOut(duration)
                .OnComplete(()=> gameObject.SetActive(false))
                .IgnoreTimeScale().SetLink(gameObject);
            return _mainTween;
        }


    }
}
