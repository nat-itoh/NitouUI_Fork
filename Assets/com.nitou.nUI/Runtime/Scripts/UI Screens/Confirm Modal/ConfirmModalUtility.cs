using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace nitou.UI {

    public static class ConfirmModalUtility {

        /// <summary>
        /// �P�I�����̊m�F���[�_����\������
        /// </summary>
        public async static UniTask PushAndPop_OneChiceConfirmModal(
            this ModalContainer container,
            string resourceKey, bool playAnimation = true
            ) {

            bool isCliced = false;

            await container.Push<OneChiceConfirmModal>(resourceKey, playAnimation,
                onLoad: x => {
                    var modal = x.modal;

                    // ���N���b�N���̏���
                    void OnClick() {
                        isCliced = true;
                        container.Pop(true);
                    }

                    // �o�C���h
                    modal.OnOkButtonClicked.Subscribe(_ => OnClick());
                });

            await UniTask.WaitUntil(() => isCliced);
        }

        /// <summary>
        /// �Q�I�����̊m�F���[�_����\������
        /// </summary>
        public async static UniTask<bool> PushAndPop_TwoChiceConfirmModal(
            this ModalContainer container,
            string resourceKey, bool playAnimation = true
            ) {

            bool isCliced = false;
            bool result = false;

            await container.Push<TwoChoiceConfirmModal>(resourceKey, playAnimation,
                onLoad: x => {
                    var modal = x.modal;

                    // ���N���b�N���̏���
                    void OnClick(bool value) {
                        isCliced = true;
                        result = value;
                        Debug_.Log(result ? "Yes" : "No");
                        container.Pop(true);
                    }

                    // �o�C���h
                    modal.OnYesButtonClicked.Subscribe(_ => OnClick(true));
                    modal.OnNoButtonClicked.Subscribe(_ => OnClick(false));
                });

            await UniTask.WaitUntil(() => isCliced);
            return result;
        }
    }

}