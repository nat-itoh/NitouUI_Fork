using UnityEngine;

// [参考]
//  qiita: VContainer入門(5) - EntryPoint https://qiita.com/sakano/items/872a9e4cdf14be0f0c61

namespace VContainer {

    /// <summary>
    /// <see cref="IObjectResolver"/>の基本的な拡張メソッド集
    /// </summary>
    public static class ObjectResolverExtensions {

        /// <summary>
        /// VContainerインターフェースを実装しないクラスをEntryPointとして登録する拡張メソッド
        /// </summary>
        public static RegistrationBuilder RegisterPlainEntryPoint<T>(this IContainerBuilder builder, Lifetime lifetime = Lifetime.Singleton) {
            builder.RegisterBuildCallback(objectResolver => objectResolver.Resolve<T>());
            return builder.Register<T>(lifetime);
        }

    }

}