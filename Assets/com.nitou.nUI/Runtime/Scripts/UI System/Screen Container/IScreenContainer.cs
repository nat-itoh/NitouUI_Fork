using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace nitou.UI {

    public interface IScreenContainer {


        int PageCount { get; }
        int ModalCount { get; }

        bool ExistPage { get; }
        bool ExistModal { get; }

        /// <summary>
        /// �A�N�e�B�u�ȉ�ʂ��|�b�v����
        /// </summary>
        public UniTask Pop(bool playAnimation);

        /// <summary>
        /// �w�萔��<see cref="Page"/>���|�b�v����
        /// </summary>
        public UniTask PopPage(bool playAnimation, int popCount = 1);

        /// <summary>
        /// �w�萔��<see cref="Modal"/>���|�b�v����
        /// </summary>
        public UniTask PopModal(bool playAnimation, int popCount = 1);

        /// <summary>
        /// �S�Ẳ�ʂ��|�b�v����
        /// </summary>
        public UniTask PopAll(bool playAnimation);

    }
}
