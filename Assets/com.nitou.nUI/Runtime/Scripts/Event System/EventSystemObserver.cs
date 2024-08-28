using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

namespace nitou.UI {

    public class EventSystemObserver : MonoBehaviour {

        private Subject<Selectable> _onSelectableSelected = new();
        private GameObject _lastSelected = null;

        /// <summary>
        /// UI��EventSystem�ɑI�����ꂽ�Ƃ��̒ʒm
        /// </summary>
        public System.IObservable<Selectable> OnSelected => _onSelectableSelected;


        void Start() {

            // EventSystem�̃f�t�H���g���W���[�����擾
            var eventSystem = EventSystem.current;
            if (eventSystem != null) {
                Observable.EveryUpdate()
                    .Select(_ => eventSystem.currentSelectedGameObject)
                    .Where(current => current != null && current != _lastSelected)  // �O�t���[���ƈقȂ鎞����
                    .Select(current => current.GetComponent<Selectable>())
                    .Subscribe(selectable => {
                        _lastSelected = eventSystem.currentSelectedGameObject;
                        _onSelectableSelected.OnNext(selectable);
                    })
                    .AddTo(gameObject);
            }

            // Selectable���I�����ꂽ���̏���
            _onSelectableSelected.Subscribe(selectable => {
                Debug.Log("Selected Selectable: " + selectable.name);
                // �����ɏ�����ǉ�����
            });
        }

        private void OnDestroy() {
            _onSelectableSelected.OnCompleted();
            _onSelectableSelected.Dispose();
        }
    }

}