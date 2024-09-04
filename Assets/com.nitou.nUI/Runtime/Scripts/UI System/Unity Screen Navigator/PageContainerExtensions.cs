using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

// [�Q�l]
//  LIGHT11: Reflection���g���ă��\�b�h���Ă񂾂�ϐ���������������L���b�V�����č����������肷�� https://light11.hatenadiary.com/entry/2019/05/27/213206

namespace UnityScreenNavigator.Runtime.Core.Page {

    /// <summary>
    /// <see cref="PageContainer"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class PageContainerExtensions {

        /// ----------------------------------------------------------------------------
        // Public Method (Page�̒ǉ�)

        /// <summary>
        /// �Ԃ�l��Page��Ԃ�Push()�̊g�����\�b�h
        /// </summary>
        public static async UniTask<TPage> PushPage<TPage>(this PageContainer container,
            string resourceKey, bool playAnimation, bool stack = true,
            string pageId = null, bool loadAsync = true,
            Action<(string pageId, TPage page)> onLoad = null) 
            where TPage : Page {

            if (container == null) throw new ArgumentNullException(nameof(container));

            // Page�ǂݍ���
            TPage page = null;
            await container.Push<TPage>(resourceKey, playAnimation, stack, pageId, loadAsync,
                x => {
                    page = x.page;
                    onLoad?.Invoke(x);
                });
            return page;
        }

        /// <summary>
        /// �Ԃ�l��Page��Ԃ�Push()�̊g�����\�b�h
        /// </summary>
        public static async UniTask<Page> PushPage(this PageContainer container,
            string resourceKey, bool playAnimation, bool stack = true,
            string pageId = null, bool loadAsync = true,
            Action<(string pageId, Page page)> onLoad = null) {

            if (container == null) throw new ArgumentNullException(nameof(container));

            // Page�ǂݍ���
            Page page = null;
            await container.Push<Page>(resourceKey, playAnimation, stack, pageId, loadAsync,
                x => {
                    page = x.page;
                    onLoad?.Invoke(x);
                });
            return page;
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Page�̎擾)

        /// <summary>
        /// �A�N�e�B�u��Modal���擾����
        /// </summary>
        public static Page GetActivePage(this PageContainer container) {
            if (container.Pages.Count == 0) return null;

            var pageId = container.OrderedPagesIds[container.Pages.Count - 1];
            return container.Pages[pageId];
        }

        /// <summary>
        /// �A�N�e�B�u��Modal���擾����
        /// </summary>
        public static bool TryGetActivePage(this PageContainer container, out Page page) {
            page = container.GetActivePage();
            return page != null;
        }

        /// <summary>
        /// �L�[���w�肵��Modal���擾����
        /// </summary>
        public static bool TryGetPage(this PageContainer container, string resourceKey, out Page page) {
            return container.Pages.TryGetValue(resourceKey, out page);
        }

        /// <summary>
        /// �L�[���w�肵��Modal���擾����
        /// </summary>
        public static bool TryGetPage<TPage>(this PageContainer container, string resourceKey, out TPage page) 
            where TPage : Page{
                        
            if(container.Pages.TryGetValue(resourceKey, out var tmp) && tmp is TPage) {
                page = (TPage)tmp;
                return true;
            }

            page = default;
            return false;
        }


        /// ----------------------------------------------------------------------------
        // Public Method ()

        public static IDisposable SetUninteractable(this PageContainer container) {
            container.Interactable = false;

            return Disposable.Create(() => {
                container.Interactable = true;
            });
        }

        /// <summary>
        /// ���t���N�V�����ŃR���e�i�L�[�ϐ�������������g�����\�b�h
        /// </summary>
        public static void SetContainerKey(this PageContainer container, string key) {
            var fieldInfo = container.GetType()
                .GetField("_name", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null) fieldInfo.SetValue(container, key);
        }
    }
}
