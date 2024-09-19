using System;

namespace UnityScreenNavigator.Runtime.Core {
    using Page;
    using Modal;
    using Sheet;

    /// <summary>
    /// �v���[���^�[��\���C���^�[�t�F�[�X
    /// </summary>
    public interface IPresenter : IDisposable {
        bool IsDisposed { get; }
        bool IsInitialized { get; }
        void Initialize();
    }

    /// <summary>
    /// Page�v���[���^�[
    /// </summary>
    public interface IPagePresenter : IPresenter, IPageLifecycleEvent { }

    /// <summary>
    /// Sheet�v���[���^�[
    /// </summary>
    public interface ISheetPresenter : IPresenter, ISheetLifecycleEvent { }

    /// <summary>
    /// Modal�v���[���^�[
    /// </summary>
    public interface IModalPresenter : IPresenter, IModalLifecycleEvent { }
}
