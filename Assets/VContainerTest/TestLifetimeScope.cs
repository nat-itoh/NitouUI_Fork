using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestLifetimeScope : LifetimeScope {

    // testMonoBehaviourをインスペクタで設定する
    [SerializeField] private TestMonoBehaviour testMonoBehaviour;

    protected override void Configure(IContainerBuilder builder) {

        builder.Register<Logger>(Lifetime.Singleton);
        builder.Register<Calculator>(Lifetime.Singleton);
        builder.Register<HogeClass>(Lifetime.Singleton);

        // testMonoBehaviourのインスタンスを登録する
        builder.RegisterComponent(testMonoBehaviour);
    }
}
