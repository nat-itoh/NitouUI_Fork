using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    [AddComponentMenu(menuName: "UI/Custom/DropArea")]
    [RequireComponent(typeof(CanvasGroup), typeof(Image))]
    public class DropArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

        [Title("Components")]
        [SerializeField] private Graphic _highlight;
        [SerializeField] private Transform _cursorTrans;
        
        private CanvasGroup _canvasGroup;
        private Image _image;

        // Dropableパラメータ
        private float _dropableAlpha = 1f;
        private float _undropableAlpha = 0.2f;

        // Highrightパラメータ
        [Title("Color")]
        [OdinIgnore]
        [SerializeField] private Color _defaultColor;

        public bool IsDropable { get; set; } = false;

        // 内部処理用
        private Tween _cursorTween;
        private Vector3 _cursorDefaultScale;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        private void Start() {
            _canvasGroup = GetComponent<CanvasGroup>();
            _image = GetComponent<Image>();
            _canvasGroup.alpha = 0.2f;

            _highlight.enabled = false;
            _cursorTrans.gameObject.SetActive(false);
            _cursorDefaultScale = _cursorTrans.localScale;

            SetDefaultColor();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// ドロップが可能かどうかを設定する
        /// </summary>
        public void SetDropablity(bool value) {
            IsDropable = value;

            if (value) {
                _canvasGroup.DOFade(_dropableAlpha, 0.2f).SetLink(gameObject);

            } else {
                _canvasGroup.DOFade(_undropableAlpha, 0.2f).SetLink(gameObject);
                _cursorTrans.gameObject.SetActive(false);
            }
        }

        public void SetColor(Color color) {
            _image.color = color;
            _highlight.color = color;
        }

        public void SetDefaultColor() => SetColor(_defaultColor);


        /// ----------------------------------------------------------------------------
        // Interface Method

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) {
            if (IsDropable) {
                _highlight.enabled = true;

                _cursorTrans.gameObject.SetActive(true);
                var scale = _cursorDefaultScale * 1.1f;
                _cursorTween = _cursorTrans.DOScale(scale, 0.8f)
                    .SetLoops(-1, LoopType.Restart)
                    .SetLink(gameObject);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) {
            _highlight.enabled = false;
            _cursorTween?.Kill();
            _cursorTrans.gameObject.SetActive(false);
            _cursorTrans.localScale = _cursorDefaultScale;
        }

    }


}