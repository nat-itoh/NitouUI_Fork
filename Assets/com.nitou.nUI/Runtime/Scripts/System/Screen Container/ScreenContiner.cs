using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using Sirenix.OdinInspector;

namespace nitou.UI {

    /// <summary>
    /// ��ʃ^�C�v
    /// </summary>
    public enum ScreenType {
        None,
        Page,
        Modal,
        Overlay,
    }


    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScreenContiner : MonoBehaviour, IScreenContainer {

        [Title("Containers")]
        [SerializeField, Indent] private PageContainer _pageContainer;
        [SerializeField, Indent] private ModalContainer _modalContainer;
        [SerializeField, Indent] private ModalContainer _overlayContainer;

        private readonly ReactiveProperty<ScreenType> _currentType = new(ScreenType.None);


        /// ----------------------------------------------------------------------------
        #region Properity

        /// <summary>
        /// �ʏ��ʂ̃R���e�i
        /// </summary>
        public PageContainer PageContainer {
            get => _pageContainer;
            internal set => _pageContainer = value;
        }

        /// <summary>
        /// �|�b�v�A�b�v��ʂ̃R���e�i
        /// </summary>
        public ModalContainer ModalContainer {
            get => _modalContainer;
            internal set => _modalContainer = value;
        }

        /// <summary>
        /// �J�ډ�ʂ̃R���e�i
        /// </summary>
        public ModalContainer OverlayContainer {
            get => _modalContainer;
            internal set => _modalContainer = value;
        }


        /// <summary>
        /// �A�N�e�B�u�ȉ�ʃ^�C�v
        /// </summary>
        [Title("State Informatin")]
        [GUIColor(0f, 1f, 0.5f)]
        [ShowInInspector, ReadOnly, Indent]
        public IReadOnlyReactiveProperty<ScreenType> CurrentType => _currentType;

        /// <summary>
        /// Push����Ă���y�[�W��
        /// </summary>
        [ShowInInspector, ReadOnly, Indent]
        public int PageCount => (_pageContainer != null) ? _pageContainer.Pages.Count : 0;

        /// <summary>
        /// Push����Ă��郂�[�_����
        /// </summary>
        [ShowInInspector, ReadOnly, Indent]
        public int ModalCount => (_modalContainer != null) ? _modalContainer.Modals.Count : 0;

        /// <summary>
        /// �y�[�W�����݂��邩�ǂ���
        /// </summary>
        public bool ExistPage => PageCount >= 1;

        /// <summary>
        /// ���[�_�������݂��邩�ǂ���
        /// </summary>
        public bool ExistModal => ModalCount >= 1;

        /// <summary>
        /// ��ʑJ�ڒ����ǂ���
        /// </summary>
        public bool IsInTransition => _pageContainer.IsInTransition || _modalContainer.IsInTransition;

        #endregion


        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method


        private void OnDestroy() {
            _currentType?.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Push)

        /// <summary>
        /// Page��ǉ����āC�X�V�������s���D
        /// </summary>
        public async UniTask<TPage> PushPage<TPage>(string resourceKey, bool playAnimation,
            bool stack = true, string pageId = null, bool loadAsync = true,
            Action<(string pageId, TPage page)> onLoad = null) where TPage : Page {

            if (IsInTransition) {
                Debug_.LogWarning("�J�ڒ���Page��Push�ł��܂���D", Colors.Red);
                return null;
            }
            if (ExistModal) {
                Debug_.LogWarning("Modal���\������Ă��邽�߁CPage��ǉ��ł��܂���", Colors.Red);
                return null;
            }

            // Page������ꍇ�C
            if (ExistPage) {
                _pageContainer.GetActivePage().SetInteractable(false);
            }


            // Page�̒ǉ�
            TPage page = await _pageContainer.PushPage<TPage>(resourceKey, playAnimation, stack, pageId, loadAsync, onLoad);
            page.SetInteractable(true);

            // �X�e�[�g���̍X�V
            UpdateStateInfo();

            return page;
        }


        /// <summary>
        /// ���[�_����Push����
        /// </summary>
        public async UniTask<TModal> PushModal<TModal>(string resourceKey, bool playAnimation,
            string modalId = null, bool loadAsync = true,
            Action<(string modalId, TModal modal)> onLoad = null) where TModal : Modal {

            if (IsInTransition) {
                Debug_.LogWarning("�J�ڒ���Modal��Push�ł��܂���D", Colors.Red);
                return null;
            }

            // Modal������ꍇ
            if (ExistModal) {
                _modalContainer.GetActiveModal().SetInteractable(false);
            }
            // Page������ꍇ
            else if (ExistPage) {
                _pageContainer.GetActivePage().SetInteractable(false);
            }


            // Modal�̒ǉ�
            TModal modal = await _modalContainer.PushModal<TModal>(resourceKey, playAnimation, modalId, loadAsync, onLoad);
            modal.SetInteractable(true);

            // �X�e�[�g���̍X�V
            UpdateStateInfo();

            return modal;
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Pop)

        /// <summary>
        /// �A�N�e�B�u��<see cref="Page"/>���|�b�v����.
        /// </summary>
        public async UniTask PopPage(bool playAnimation, int popCount = 1) {
            if (!ExistPage) return;
            if (popCount <= 0 || PageCount < popCount) return;

            if (IsInTransition) {
                Debug_.LogWarning("�J�ڒ���Pop�J�ڂ��s���܂���D", Colors.Red);
                return;
            }
            if (ExistModal) {
                Debug_.LogWarning("Modal���\������Ă��邽�߁CPage���폜�ł��܂���", Colors.Red);
                return;
            }

            _pageContainer.GetActivePage().SetInteractable(false);

            // Page�̍폜
            await _pageContainer.Pop(playAnimation, popCount);

            // �X�e�[�g���̍X�V
            UpdateStateInfo();

            // Selectable�ݒ�
            if (ExistPage) {
                var page = _pageContainer.GetActivePage();
                page.SetInteractable(true);
            }
        }

        /// <summary>
        /// �A�N�e�B�u��<see cref="Modal"/>���|�b�v����.
        /// </summary>
        public async UniTask PopModal(bool playAnimation, int popCount = 1) {
            if (!ExistModal) return;
            if (popCount <= 0 || ModalCount < popCount) return;

            if (IsInTransition) {
                Debug_.LogWarning("�J�ڒ��̓��[�_����Pop�ł��܂���D", Colors.Red);
                return;
            }

            // �I����Ԃ̉���
            _modalContainer.GetActiveModal().SetInteractable(false);

            // Modal�̍폜
            await _modalContainer.Pop(playAnimation, popCount);

            // �X�e�[�g���̍X�V
            UpdateStateInfo();

            // �܂����[�_�������݂���ꍇ�C
            if (ExistModal) {
                Debug_.Log($"�܂����[�_���͂��邺�Dname :{_modalContainer.GetActiveModal().name}");
                var modal = _modalContainer.GetActiveModal();
                modal.SetInteractable(true);
            }
            // ��Modal����Page�ɐ��䂪�ς�����ꍇ�C
            else if (ExistPage) {
                Debug_.Log($"Switch controll [Modal => Page]", Colors.Orange);
                var page = _pageContainer.GetActivePage();
                page.SetInteractable(true);
            }
        }

        /// <summary>
        /// �A�N�e�B�u�ȉ�ʂ��|�b�v����
        /// </summary>
        public async UniTask Pop(bool playAnimation) {
            // �J�ڒ��̏ꍇ�C�G���[�𓊂���
            if (IsInTransition)
                throw new InvalidOperationException("�J�ڒ���Page/Modal��Pop���s���܂���D");

            if (ExistModal) {
                await PopModal(playAnimation);

            } else if (ExistPage) {
                await PopPage(playAnimation);

            } else {
                throw new InvalidOperationException("�R���e�i��Page/Modal�����݂��Ȃ����߁CPop�J�ڂ��s���܂���.");
            }
        }

        /// <summary>
        /// �S�Ă�Page�CModal���|�b�v����
        /// </summary>
        public async UniTask PopAll(bool playAnimation = false) {
            await PopModal(playAnimation, ModalCount);
            await PopPage(playAnimation, PageCount);
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// �X�^�b�N��ԂɊ�Â��ăA�N�e�B�u���[�h���X�V����
        /// </summary>
        private void UpdateStateInfo() {

            if (ExistModal) {
                _currentType.Value = ScreenType.Modal;

            } else if (ExistPage) {
                _currentType.Value = ScreenType.Page;

            } else {
                _currentType.Value = ScreenType.None;
            }
        }
    }
}
