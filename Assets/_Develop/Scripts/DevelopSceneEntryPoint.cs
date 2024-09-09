using VContainer;
using VContainer.Unity;
using UnityEngine;
using Sirenix.OdinInspector;
using nitou.Framework;
using nitou.UI;

namespace Develop {

    public sealed class DevelopSceneEntryPoint : SceneEntryPoint {

        [Space]

        [Title("References")]
        [SerializeField, Indent] ScreenContiner _screenContiner;

        protected override void Configure(IContainerBuilder builder) {




        }
    }



    public sealed class TestLauncher {





    }
}