using UnityEngine;

namespace nitou.UI.Component {

    public interface IIconView {

        /// <summary>
        /// �X�v���C�g��ݒ肷��
        /// </summary>
        public void SetSprite(Sprite sprite);

        /// <summary>
        /// �X�v���C�g�̃l�C�e�B�u�T�C�Y��K�p����
        /// </summary>
        public void SetNativeSize(float scale);
    }
}
