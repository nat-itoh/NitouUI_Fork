using UnityEngine;

// [�Q�l]
//  qiita: VContainer����(5) - EntryPoint https://qiita.com/sakano/items/872a9e4cdf14be0f0c61

namespace VContainer {

    /// <summary>
    /// <see cref="IObjectResolver"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ObjectResolverExtensions {

        /// <summary>
        /// VContainer�C���^�[�t�F�[�X���������Ȃ��N���X��EntryPoint�Ƃ��ēo�^����g�����\�b�h
        /// </summary>
        public static RegistrationBuilder RegisterPlainEntryPoint<T>(this IContainerBuilder builder, Lifetime lifetime = Lifetime.Singleton) {
            builder.RegisterBuildCallback(objectResolver => objectResolver.Resolve<T>());
            return builder.Register<T>(lifetime);
        }

    }

}