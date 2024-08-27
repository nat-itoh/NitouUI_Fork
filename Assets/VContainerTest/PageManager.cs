using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

public class PageManager : IInitializable {

    private PageContainer _miniPageContainer;
    private IObjectResolver _resolver;

    [Inject]
    public PageManager(PageContainer miniPageContainer, IObjectResolver resolver) {
        _miniPageContainer = miniPageContainer;
        _resolver = resolver;
    }

    public void Initialize() {
        _miniPageContainer.AddCallbackReceiver(new VContainerPageCallbackRegister(_resolver));
    }
    public async void ChangePage(string pageName) {
        await _miniPageContainer.Push(pageName, true).ToUniTask();
    }
}
