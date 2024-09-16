using VContainer;
using VContainer.Unity;

namespace nitou.UI.ScreenSystem {

    public class LifetimeScopeWithParameter<T> : LifetimeScope {

        protected T Parameter;

        protected override void Configure(IContainerBuilder builder) {
            base.Configure(builder);
            builder.RegisterInstance(Parameter);
        }

        /// <summary>
        ///  
        /// </summary>
        public void SetParameter(T parameter) {
            Parameter = parameter;
        }
    }
}
