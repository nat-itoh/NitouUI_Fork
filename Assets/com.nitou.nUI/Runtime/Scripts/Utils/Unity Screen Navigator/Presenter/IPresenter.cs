using System;

namespace UnityScreenNavigator.Runtime.Core {
    using Page;
    using Modal;
    using Sheet;

    /// <summary>
    /// プレゼンターを表すインターフェース
    /// </summary>
    public interface IPresenter : IDisposable {
        bool IsDisposed { get; }
        bool IsInitialized { get; }
        void Initialize();
    }

    /// <summary>
    /// Pageプレゼンター
    /// </summary>
    public interface IPagePresenter : IPresenter, IPageLifecycleEvent { }

    /// <summary>
    /// Sheetプレゼンター
    /// </summary>
    public interface ISheetPresenter : IPresenter, ISheetLifecycleEvent { }

    /// <summary>
    /// Modalプレゼンター
    /// </summary>
    public interface IModalPresenter : IPresenter, IModalLifecycleEvent { }
}
