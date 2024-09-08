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
        /// ���b�Z�[�W��ݒ肷��
        /// </summary>
        public void SetMessage(string message) {
            if (_messageText == null) return;
            _messageText.text = message;
        }

        /// <summary>
        /// <see cref="IUISelectable"/>���I�����ꂽ�Ƃ��̕\�����b�Z�[�W��o�^����
        /// </summary>
        public IDisposable RegisterObservable(IUISelectable selectable, string message) {
            if (_disposables == null) _disposables = new();
            return selectable.OnSelected.Subscribe(_ => SetMessage(message)).AddTo(_disposables);
        }

        /// <summary>
        /// �S�Ă̓o�^���b�Z�[�W����������
        /// </summary>
        public void UnRegisterAll() {
            _disposables?.Dispose();
        }

    }
}
