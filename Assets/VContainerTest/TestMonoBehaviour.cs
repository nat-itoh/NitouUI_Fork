using UnityEngine;
using VContainer;

public sealed class TestMonoBehaviour : MonoBehaviour {
    private HogeClass hogeClass;

    [Inject]
    public void Inject(HogeClass hogeClass) {
        this.hogeClass = hogeClass;
    }

    public void Start() {
        hogeClass.CalculatorTest(2, 3); // 2 + 3 = 5 ‚Æ•\Ž¦‚³‚ê‚é
    }
}
