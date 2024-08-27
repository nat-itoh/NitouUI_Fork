using UnityEngine;
using VContainer;
using VContainer.Unity;

public class TestLifetimeScope : LifetimeScope {

    // testMonoBehaviour���C���X�y�N�^�Őݒ肷��
    [SerializeField] private TestMonoBehaviour testMonoBehaviour;

    protected override void Configure(IContainerBuilder builder) {

        builder.Register<Logger>(Lifetime.Singleton);
        builder.Register<Calculator>(Lifetime.Singleton);
        builder.Register<HogeClass>(Lifetime.Singleton);

        // testMonoBehaviour�̃C���X�^���X��o�^����
        builder.RegisterComponent(testMonoBehaviour);
    }
}
