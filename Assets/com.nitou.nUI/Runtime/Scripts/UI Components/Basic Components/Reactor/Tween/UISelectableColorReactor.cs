using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace nitou.UI.Component {

    /// <summary>
    /// �Ǝ�UI�ɃJ���[�C�x���g��o�^����R���|�[�l���g
    /// </summary>
    public class UISelectableColorReactor : UISelectableTweenReactor<Graphic, Color> {

        /// ----------------------------------------------------------------------------
        // Field

        /// <summary>
        /// ��I����Ԃ̃J���[
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplyDeselectedValue", SdfIconType.Droplet, label: " ")]
        [OdinIgnore]
        [SerializeField] Color _deselectedColor = Colors.LightGray;

        /// <summary>
        /// �I����Ԃ̃J���[
        /// </summary>
        [TitleGroup(GroupKey.TWEEN_PARAM), Indent]
        [InlineButton("ApplySelectedValue", SdfIconType.Droplet, label: " ")]
        [OdinIgnore]
        [SerializeField] Color _selectedColor = Colors.LightGray;


        /// ----------------------------------------------------------------------------
        // Properity

        public override Color DeselectedValue {
            get => _deselectedColor;
            set => _deselectedColor = value;
        }

        public override Color SelectedValue {
            get => _selectedColor;
            set => _selectedColor = value;
        }

        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 
        /// </summary>
        protected override Tween GetTween(Graphic target, Color value) {
            return target.DOColor(value, _duration);
        }

        /// <summary>
        /// �S�Ẵ^�[�Q�b�g���I�����̉��o��Ԃɂ���
        /// </summary>
        protected override void SetValueImmediately(Color value) {
            _targetList.ForEach(x => x.color = value);
        }

    }

}