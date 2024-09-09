using UnityEngine;
using VContainer;
using VContainer.Unity;
using Sirenix.OdinInspector;

namespace nitou.Framework {

    public enum SceneType {
        
        /// <summary>
        /// ���C���̃��x���D
        /// </summary>
        MainLevel,

        /// <summary>
        /// �t���I�ȃ��x���D
        /// </summary>
        SubLevel,
        
        /// <summary>
        /// ���̑�
        /// </summary>
        Other
    }


    public abstract class SceneEntryPoint : LifetimeScope {

        [EnumToggleButtons, HideLabel]
        [PropertyOrder(-1)]
        [SerializeField, Indent] SceneType _type;
    }

}