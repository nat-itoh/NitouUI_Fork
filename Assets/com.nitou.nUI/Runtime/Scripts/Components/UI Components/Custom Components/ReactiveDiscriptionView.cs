using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Sirenix.OdinInspector;

namespace nitou.UI.Component{

    [DisallowMultipleComponent]
    public class ReactiveDiscriptionView : UIBehaviour, IUIComponent {

        [SerializeField] private TextMeshProUGUI _messageText;

        private CompositeDisposable _disposables;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void OnDestroy() {
            UnRegisterAll();
            base.OnDestroy();
        }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// メッセージを設定する
        /// </summary>
        public void SetMessage(string message) {
            if (_messageText == null) return;
            _messageText.text = message;
        }

        /// <summary>
        /// <see cref="IUISelectable"/>が選択されたときの表示メッセージを登録する
        /// </summary>
        public IDisposable RegisterObservable(IUISelectable selectable, string message) {
            if (_disposables == null) _disposables = new();
            return selectable.OnSelected.Subscribe(_ => SetMessage(message)).AddTo(_disposables);
        }

        /// <summary>
        /// 全ての登録メッセージを解除する
        /// </summary>
        public void UnRegisterAll() {
            _disposables?.Dispose();
        }

    }
}
