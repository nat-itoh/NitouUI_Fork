using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace nitou.UI {

    public static class ScreenContainerCreationMenu {



        public static void CreatePageContainer() {
            var obj = new GameObject("Page Container");
            var container = obj.AddComponent<PageContainer>();
        }

        public static void CreateModalContainer() { }
        public static void CreateOverlayContainer() { }

    }
}
