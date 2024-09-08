using System.Threading.Tasks;
using UnityEngine.UI;

namespace nitou.UI {
    using nitou.UI.PresentationFramework;

    public sealed class TitlePage : Page<TitleView, TitleViewState> {


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// I—¹ˆ—
        /// </summary>
        public override Task Cleanup() {
            return base.Cleanup();
        }
    }
}
