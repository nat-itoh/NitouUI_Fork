using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// 独自UIにアクティベーションイベントを登録するコンポーネント
    /// </summary>
    public class UISelectableActivationReactor : UISelectableReactorBase<GameObject, bool> {

        /// ----------------------------------------------------------------------------
        // MonoBehaviour Method

        protected override void OnDisable() {
            base.OnDisable();
            ApplySelectedValue();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 初期化処理
        /// </summary>
        protected override void InitializeInternal() => ApplyDeselectedValue();

        /// <summary>
        /// アクティブ状態を適用する
        /// </summary>
        protected override void ApplyValue(bool value) {
            _targetList.ForEach(x => x.SetActive(value));
        }

        /// <summary>
        /// 非選択時の値を適用する
        /// </summary>
        protected override void ApplyDeselectedValue() => ApplyValue(false);

        /// <summary>
        /// 選択時の値を適用する
        /// </summary>
        protected override void ApplySelectedValue() => ApplyValue(true);
    }

}