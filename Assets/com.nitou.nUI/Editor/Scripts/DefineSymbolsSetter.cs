#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;

// [参考]
//  はなちる: Player SettingsのScriptingDefineSymbolsをスクリプトから取得・設定する方法 https://www.hanachiru-blog.com/entry/2024/06/03/120000

namespace nitou.UI.EditorScripts {

    /// <summary>
    /// シンボルの設定を行うクラス
    /// </summary>
    [InitializeOnLoad]
    internal static class DefineSymbolsSetter{

        // 定義したいシンボルの配列
        private static readonly string[] SYMBOL_ARRAY = {
            // UnityScreenNavigatorでTaskを使用するために必要
            "USN_USE_ASYNC_METHODS",
            // DOTweenでToUnitask()を使用するために必要
            "UNITASK_DOTWEEN_SUPPORT"
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static DefineSymbolsSetter() {
            // パッケージがインストールされたときに実行される処理
            AddDefineSymbolsIfNeeded();
        }

        /// <summary>
        /// シンボルを定義する
        /// </summary>
        private static void AddDefineSymbolsIfNeeded() {

            // 現在のビルドターゲットごとの定義済みのシンボルを取得
            var target = NamedBuildTarget.FromBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            string defines = PlayerSettings.GetScriptingDefineSymbols(target);

            // シンボル配列をチェックし、未定義のものがあれば追加
            foreach (var symbol in SYMBOL_ARRAY) {
                if (!defines.Contains(symbol)) {
                    defines += ";" + symbol;
                    Debug.Log($"Added define symbol: {symbol}");
                } 
            }
             
            // シンボルを設定
            PlayerSettings.SetScriptingDefineSymbols(target, defines);
        }
    }
}
#endif
