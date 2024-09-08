using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// ��{�@�\�݂̂̓Ǝ��X���C�_�[UI
    /// </summary>
    [AddComponentMenu(menuName: UIComponentMenu.Prefix.UIComponent + "UI Slider")]
    public class UISlider : Slider, IUISlider {

        private readonly Subject<Unit> _onSelectSubject = new();
        private readonly Subject<Unit> _onDeselectSubject = new();


        /// ----------------------------------------------------------------------------
        // Properity

        /// <summary>
        /// �l���X�V���ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<float> OnValuChanged => base.onValueChanged.AsObservable();

        /// <summary>
        /// �I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnSelected => _onSelectSubject;

        /// <summary>
        /// ��I�����ꂽ���̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnDeselected => _onDeselectSubject;


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void OnDestroy() {
            _onSelectSubject?.Dispose();
            _onSelectSubject?.Dispose();

            base.OnDestroy();
        }


        /// ----------------------------------------------------------------------------
        // Interface Method


        /// <summary>
        /// �I�����ꂽ�Ƃ��̏���
        /// </summary>
        public override void OnSelect(BaseEventData eventData) {
            base.OnSelect(eventData);
            _onSelectSubject.OnNext(Unit.Default);
        }

        /// <summary>
        /// �I�����ꂽ�Ƃ��̏���
        /// </summary>
        public override void OnDeselect(BaseEventData eventData) {
            base.OnDeselect(eventData);
            _onDeselectSubject.OnNext(Unit.Default);
        }

    }

}