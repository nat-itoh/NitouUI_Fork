using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace nitou.UI.Overlay {

    /// <summary>
    /// オーバレイの基底クラス
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class OverlayBase : MonoBehaviour, IUIOverlay {

        public enum State {
            Open,
            Transition,
            Close,
        }

        protected CanvasGroup _canvasGroup;
        public State OverlayState { get; private set; }

        /// <summary>
        /// 蓋絵が閉じた状態かどうか
        /// </summary>
        public bool IsClose => OverlayState == State.Close;

        /// <summary>
        /// 蓋絵が閉じた状態かどうか
        /// </summary>
        public bool IsOpen => OverlayState == State.Open;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Methord 

        protected void Awake() {
            _canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();

            // 初期化処理
            Initialize();

            // 開いた状態にしておく
            OpenInternal(0f).Forget();
            OverlayState = State.Open;
        }

        protected virtual void Initialize() {}


        /// ----------------------------------------------------------------------------
        // Public Methord

        /// <summary>
        /// Progress: 1→0の画面遷移アニメーション
        /// </summary>
        public async UniTask OpenAsync(float duration = 1f) {
            // ※完全に閉じた状況でなければ終了
            if (!IsClose) return;

            OverlayState = State.Transition;
            await OpenInternal(duration);
            OverlayState = State.Open;
        }

        /// <summary>
        /// Progress: 0→1の画面遷移アニメーション
        /// </summary>
        public async UniTask CloseAsync(float duration = 1f) {
            // ※完全に開いた状況でなければ終了
            if (!IsOpen) return;

            OverlayState = State.Transition;
            await CloseInternal(duration);
            OverlayState = State.Close;
        }


        /// ----------------------------------------------------------------------------
        // Public Methord (遷移アニメーション)

        protected abstract UniTask OpenInternal(float duration);

        protected abstract UniTask CloseInternal(float duration);
    }

}