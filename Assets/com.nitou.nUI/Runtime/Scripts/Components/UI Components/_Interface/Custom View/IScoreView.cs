using UnityEngine;

namespace nitou.UI.Component {

    /// <summary>
    /// �X�R�A�\����S��UI�ł��邱�Ƃ������C���^�[�t�F�[�X
    /// </summary>
    public interface IScoreTextView{

        /// <summary>
        /// �X�R�A��ݒ肷��
        /// </summary>
        public void SetScore(int value);

        /// <summary>
        /// �f�t�H���g�l��ݒ肷��
        /// </summary>
        public void SetDefaule();
    }

}