using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// �Ǝ�UI�ɃA�N�e�B�x�[�V�����C�x���g��o�^����R���|�[�l���g
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
        /// ����������
        /// </summary>
        protected override void InitializeInternal() => ApplyDeselectedValue();

        /// <summary>
        /// �A�N�e�B�u��Ԃ�K�p����
        /// </summary>
        protected override void ApplyValue(bool value) {
            _targetList.ForEach(x => x.SetActive(value));
        }

        /// <summary>
        /// ��I�����̒l��K�p����
        /// </summary>
        protected override void ApplyDeselectedValue() => ApplyValue(false);

        /// <summary>
        /// �I�����̒l��K�p����
        /// </summary>
        protected override void ApplySelectedValue() => ApplyValue(true);
    }

}