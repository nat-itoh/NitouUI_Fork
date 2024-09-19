using System.Threading.Tasks;
using UnityEngine.UI;

namespace nitou.UI{
    using nitou.UI.PresentationFramework;

    public sealed class PauseModal : Modal<PauseView, PauseViewState> {


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
