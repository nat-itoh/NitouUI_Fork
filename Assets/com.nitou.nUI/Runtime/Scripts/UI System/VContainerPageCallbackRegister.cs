using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

namespace nitou.UI.ScreenSystem {


    public class VContainerPageCallbackRegister : IPageContainerCallbackReceiver {

        private IObjectResolver _resolver;

        public VContainerPageCallbackRegister(IObjectResolver resolver) {
            _resolver = resolver;
        }


        /// ----------------------------------------------------------------------------
        #region Interface Method

        void IPageContainerCallbackReceiver.BeforePush(Page enterPage, Page exitPage) {
            _resolver.InjectGameObject(enterPage.gameObject);
        }

        void IPageContainerCallbackReceiver.AfterPush(Page enterPage, Page exitPage) {
            throw new System.NotImplementedException();
        }

        void IPageContainerCallbackReceiver.BeforePop(Page enterPage, Page exitPage) {
            throw new System.NotImplementedException();
        }

        void IPageContainerCallbackReceiver.AfterPop(Page enterPage, Page exitPage) {
            throw new System.NotImplementedException();
        }

        #endregion
    }

}