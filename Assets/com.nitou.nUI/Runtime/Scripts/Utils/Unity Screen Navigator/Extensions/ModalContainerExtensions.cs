using System;
using System.Reflection;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace UnityScreenNavigator.Runtime.Core.Modal{

    /// <summary>
    /// <see cref="ModalContainer"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class ModalContainerExtensions {

        public async static UniTask<TModal> PushModal<TModal>(this ModalContainer self,
            string resourceKey, bool playAnimation, string modalId = null, bool loadAsync = true,
            Action<(string modalId, TModal modal)> onLoad = null) where TModal: Modal{

            // Modal�̒ǉ�
            TModal modal = null;
            await self.Push<TModal>(resourceKey, playAnimation, modalId, loadAsync,
                x => {
                    modal = x.modal;
                    onLoad?.Invoke(x);
                });

            return modal;
        }



        public static bool IsEmpty(this ModalContainer container) {
            return container.Modals.Count == 0;
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Modal�̎擾)

        /// <summary>
        /// �A�N�e�B�u��Modal���擾����
        /// </summary>
        public static Modal GetActiveModal(this ModalContainer container) {
            if (container.Modals.Count <= 0) return null;

            var modalId = container.OrderedModalIds[container.Modals.Count - 1];
            return container.Modals[modalId];
        }

        /// <summary>
        /// �A�N�e�B�u��Modal���擾����
        /// </summary>
        public static bool TryGetActiveModal(this ModalContainer container, out Modal modal) {
            modal = container.GetActiveModal();
            return modal != null;
        }

        /// <summary>
        /// �A�N�e�B�u��Modal���擾����
        /// </summary>
        public static Modal GetPreviousModal(this ModalContainer container) {
            if (container.Modals.Count <= 1) return null;

            var pageId = container.OrderedModalIds[container.Modals.Count - 2];
            return container.Modals[pageId];
        }


        /// ----------------------------------------------------------------------------
        // Public Method ()

        /// <summary>
        /// ���t���N�V�����ŃR���e�i�L�[�ϐ�������������g�����\�b�h
        /// </summary>
        public static void SetContainerKey(this ModalContainer container, string key) {
            var fieldInfo = container.GetType()
                .GetField("_name", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null) fieldInfo.SetValue(container, key);
        }
    }
}
