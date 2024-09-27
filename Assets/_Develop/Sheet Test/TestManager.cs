using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Sheet;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.UI;

namespace SheetTest {

    public class TestManager : MonoBehaviour {

        // �R���e�i
        [SerializeField] SheetContainer _sheetContainer;

        // ����{�^��
        [SerializeField] Button _buttonA;
        [SerializeField] Button _buttonB;
        [SerializeField] Button _buttonC;
        [SerializeField] Button _hideButton;

        // ���\�[�X�L�[
        private static readonly string SHEET_A_KEY = "Sheet/Prefab_SheetA";
        private static readonly string SHEET_B_KEY = "Sheet/Prefab_SheetB";
        private static readonly string SHEET_C_KEY = "Sheet/Prefab_SheetC";

        private async void Start() {

            Debug.Log("Push [SPACE] key to continue.");
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            Debug.Log("Register sheets.");
            await UniTask.WhenAll(
                // �V�[�g���R���e�i�o�^�i���C���X�^���X�����������j
                _sheetContainer.Register<SheetA>(SHEET_A_KEY).ToUniTask(),
                _sheetContainer.Register<SheetB>(SHEET_B_KEY).ToUniTask(),
                _sheetContainer.Register<SheetC>(SHEET_C_KEY).ToUniTask());

            Debug.Log("Complete task.");
            Debug.Log("---------------------------");

            // �{�^���̃R�[���o�b�N�o�^
            _buttonA.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_A_KEY,true));
            _buttonB.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_B_KEY,true));
            _buttonC.onClick.AddListener(() => _sheetContainer.ShowByResourceKey(SHEET_C_KEY,true));
            _hideButton.onClick.AddListener(() => _sheetContainer.Hide(true));         
        }

    }

}