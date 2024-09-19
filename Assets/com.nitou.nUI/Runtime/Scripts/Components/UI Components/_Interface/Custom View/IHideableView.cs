using UnityEngine;
using DG.Tweening;

namespace nitou.UI.Component{

    /// <summary>
    /// �\���E��\���̐؂�ւ����\�Ȋ�{UI
    /// </summary>
    public interface IHideableView {

        public Tweener DOShow(float duration);

        public Tweener DOHide(float duration);
    }
}
