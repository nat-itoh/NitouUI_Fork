using System;

namespace UnityScreenNavigator.Runtime.Core {

    /// <summary>
    /// �v���[���^�[���N���X
    /// </summary>
    public abstract class Presenter<TView> : IDisposable {

        public bool IsInitialized { get; private set; }

        public bool IsDisposed { get; private set; }

        private TView View { get; }


        /// --------------------------------------------------------------------
        // Public Methord

        /// <summary>
        /// ����������
        /// </summary>
        public void Initialize() {
            if (IsInitialized) {
                throw new InvalidOperationException($"{GetType().Name} is already initialized.");
            }

            if (IsDisposed) {
                throw new ObjectDisposedException(nameof(Presenter<TView>));
            }

            Initialize(View);
            IsInitialized = true;
        }

        /// <summary>
        /// �I������
        /// </summary>
        public virtual void Dispose() {
            if (!IsInitialized) return;

            if (IsDisposed) return;

            Dispose(View);
            IsDisposed = true;
        }


        /// --------------------------------------------------------------------
        // Protected Methord

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        protected Presenter(TView view) {
            View = view;
        }

        protected abstract void Initialize(TView view);

        protected abstract void Dispose(TView view);
    }


    /// <summary>
    /// �v���[���^�[���N���X
    /// </summary>
    public abstract class Presenter<TView, TDataSource> : IDisposable {

        public bool IsInitialized { get; private set; }

        public bool IsDisposed { get; private set; }

        private TView View { get; }

        private TDataSource DataSource { get; }


        /// --------------------------------------------------------------------
        // Public Methord

        /// <summary>
        /// ����������
        /// </summary>
        public void Initialize() {
            if (IsInitialized) {
                throw new InvalidOperationException($"{GetType().Name} is already initialized.");
            }

            if (IsDisposed) {
                throw new ObjectDisposedException(nameof(Presenter<TView, TDataSource>));
            }

            Initialize(View, DataSource);
            IsInitialized = true;
        }

        /// <summary>
        /// �I������
        /// </summary>
        public virtual void Dispose() {
            if (!IsInitialized) return;

            if (IsDisposed) return;

            Dispose(View, DataSource);
            IsDisposed = true;
        }


        /// --------------------------------------------------------------------
        // Protected Methord

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        protected Presenter(TView view, TDataSource dataSource) {
            View = view;
            DataSource = dataSource;
        }

        protected abstract void Initialize(TView view, TDataSource dataStore);

        protected abstract void Dispose(TView view, TDataSource dataSource);
    }
}
