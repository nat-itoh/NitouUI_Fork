using System.Threading.Tasks;
using UnityEngine.UI;

namespace nitou.UI.BasicScreen {
    using nitou.UI.PresentationFramework;

    public sealed class TitlePage : Page<TitleView, TitleViewState> {


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �I������
        /// </summary>
        public override Task Cleanup() {
            return base.Cleanup();
        }
    }
}
