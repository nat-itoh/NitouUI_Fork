using System.Threading.Tasks;
using UnityEngine.UI;

namespace nitou.UI {
    using nitou.UI.PresentationFramework;

    public sealed class SettingsModal : Modal<SettingsView, SettingsViewState> {


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
