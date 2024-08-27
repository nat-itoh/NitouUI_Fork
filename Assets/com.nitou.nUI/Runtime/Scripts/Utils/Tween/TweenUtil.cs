using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: DOTween��Time.timeScale�𖳎�������@ https://baba-s.hatenablog.com/entry/2016/11/17/100000#google_vignette

namespace DG.Tweening {

    /// <summary>
    /// <see cref="Tween"/>�Ɋւ���ėp���\�b�h�W
    /// </summary>
    public static class TweenUtil{

        /// <summary>
        /// SetUpdate(true)�̓��ߍ\��
        /// </summary>
        public static T IgnoreTimeScale<T>(this T t) where T : Tween {
            return t.SetUpdate(true);
        }

    }
}
