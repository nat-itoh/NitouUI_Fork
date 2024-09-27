using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Sheet;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.UI;

namespace SheetTest {

    public class TestManager : MonoBehaviour {

        // コンテナ
        [SerializeField] SheetContainer _sheetContainer;

        // 操作ボタン
        [SerializeField] Button _buttonA;
        [SerializeField] Button _buttonB;
        [SerializeField] Button _buttonC;
        [SerializeField] Button _hideButton;

        // リソースキー
        private static readonly string SHEET_A_KEY = "Sheet/Prefab_SheetA";
        private static readonly string SHEET_B_KEY = "Sheet/Prefab_SheetB";
        private static readonly string SHEET_C_KEY = "Sheet/Prefab_SheetC";

        private async void Start() {

            Debug.Log("Push [SPACE] key to continue.");
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            Debug.Log("Register sheets.");
            await UniTask.WhenAll(
                // シートをコンテナ登録（※インスタンスが生成される）
                _sheetContainer.Register<SheetA>(SHEET_A_KEY).ToUniTask(),
                _sheetContainer.Register<SheetB>(SHEET_B_KEY).ToUniTask(),
                _sheetContainer.Register<SheetC>(SHEET_C_KEY).ToUniTask());

            Debug.Log("Complete task.");
            Debug.Log("---------------------------");

            // ボタンのコールバック登録
            _buttonA.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_A_KEY,true));
            _buttonB.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_B_KEY,true));
            _buttonC.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_C_KEY,true));
            _hideButton.onClick.AddListener(() => _sheetContainer.Hide(true));         
        }

    }

}