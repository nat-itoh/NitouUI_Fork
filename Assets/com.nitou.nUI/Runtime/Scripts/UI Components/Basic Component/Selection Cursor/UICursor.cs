using System;
using UnityEngine;
using UniRx;

namespace nitou.UI.Component {
    
    /// <summary>
    /// ��{�@�\�݂̂̓Ǝ��J�[�\��UI
    /// </summary>
    [AddComponentMenu("UI/Custom/UI Cursor")]
    [DisallowMultipleComponent]
    public class UICursor : MonoBehaviour, IUIComponent {

        // ����
        private Subject<Unit> _onEnableSubject = new();
        private Subject<Unit> _onDisableSubject = new();

        /// <summary>
        /// �A�N�e�B�u�ɂȂ������̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnEnabled => _onEnableSubject;

        /// <summary>
        /// ��A�N�e�B�u�ɂȂ������̃C�x���g�ʒm
        /// </summary>
        public IObservable<Unit> OnDisabled => _onDisableSubject;

        
        /// ----------------------------------------------------------------------------
        // Public MonoBehaviour

        private void OnEnable() {
            _onEnableSubject.OnNext(Unit.Default);
        }

        private void OnDisable() {
            _onDisableSubject.OnNext(Unit.Default);
        }

        private void OnDestroy() {
            _onEnableSubject.Dispose();
            _onDisableSubject.Dispose();
        }
    }

}