using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using Sirenix.OdinInspector;

namespace nitou.UI {

    public enum ScreenType {
        None,
        Page,
        Modal,
        Transition
    }


    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ScreenContiner : MonoBehaviour{

        [Title("Containers")]
        [SerializeField, Indent] private PageContainer _pageContainer;
        [SerializeField, Indent] private ModalContainer _modalContainer;
        [SerializeField, Indent] private ModalContainer _overlayContainer;


        public int PageCount { get; }
        public int ModalCount { get; }
        public int OverlayCount { get; }


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

        #endregion



    }
}
