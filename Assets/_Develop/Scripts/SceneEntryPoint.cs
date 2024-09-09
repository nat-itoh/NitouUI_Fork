using UnityEngine;
using VContainer;
using VContainer.Unity;
using Sirenix.OdinInspector;

namespace nitou.Framework {

    public enum SceneType {
        
        /// <summary>
        /// メインのレベル．
        /// </summary>
        MainLevel,

        /// <summary>
        /// 付属的なレベル．
        /// </summary>
        SubLevel,
        
        /// <summary>
        /// その他
        /// </summary>
        Other
    }


    public abstract class SceneEntryPoint : LifetimeScope {

        [EnumToggleButtons, HideLabel]
        [PropertyOrder(-1)]
        [SerializeField, Indent] SceneType _type;
    }

}