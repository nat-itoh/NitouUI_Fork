using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace nitou.UI.PresentationFramework {

    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Modal<TRootView, TViewState> : Modal
        where TRootView : AppView<TViewState>
        where TViewState : AppViewState {

        public TRootView root;
        private TViewState _state;

        /// <summary>
        /// 初期化済みかどうか
        /// </summary>
        public bool IsInitialized => _isInitialized;
        private bool _isInitialized;

        /// <summary>
        /// 初期化のタイミング
        /// </summary>
        protected virtual ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// View Stateの設定
        /// </summary>
        public void Setup(TViewState state) {
            Assert.IsNotNull(root);
            _state = state;
        }

#if USN_USE_ASYNC_METHODS
        public override async Task Initialize() {
            Assert.IsNotNull(root);

            await base.Initialize();

            // RootViewの初期化処理
            if (RootInitializationTiming == ViewInitializationTiming.Initialize && !_isInitialized) {
                await root.InitializeAsync(_state);
                _isInitialized = true;
            }
        }
#else
        public override IEnumerator Initialize() {
            Assert.IsNotNull(root);

            yield return base.Initialize();

            // RootViewの初期化処理
            if (RootInitializationTiming == ViewInitializationTiming.Initialize && !_isInitialized) {
                yield return root.InitializeAsync(_state).ToCoroutine();
                _isInitialized = true;
            }
        }
#endif

#if USN_USE_ASYNC_METHODS
        public override async Task WillPushEnter() {
            Assert.IsNotNull(root);

            await base.WillPushEnter();

            // RootViewの初期化処理
            if (RootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !_isInitialized) {
                await root.InitializeAsync(_state);
                _isInitialized = true;
            }
        }
#else
        public override IEnumerator WillPushEnter() {
            Assert.IsNotNull(root);

            yield return base.WillPushEnter();
            
            // RootViewの初期化処理
            if (RootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !_isInitialized){
                yield return root.InitializeAsync(_state).ToCoroutine();
                _isInitialized = true;
            }
        }
#endif
    }
}
