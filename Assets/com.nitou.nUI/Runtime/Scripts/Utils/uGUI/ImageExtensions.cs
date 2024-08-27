using UnityEngine;
using UnityEngine.UI;

// [�Q�l]
//  _: Image �N���X�̊g�����\�b�h https://kazupon.org/unity-image-extension/
//  _: 2DRPG�J������ #79 Image��Fill�������X�N���v�g����ύX���� https://kitty-pool.com/ss079/

namespace nitou {

    /// <summary>
    /// Image�̊g�����\�b�h�N���X
    /// </summary>
    public static class ImageExtensions {

        /// ----------------------------------------------------------------------------
        // Fill 

        /// <summary>
        /// Fill Origin��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetFillMethodOrigin(this Image self, Image.OriginHorizontal origin) {
            self.fillOrigin = (int)origin;
        }

        /// <summary>
        /// Fill Origin��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetFillMethodOrigin(this Image self, Image.OriginVertical origin) {
            self.fillOrigin = (int)origin;
        }

        /// <summary>
        /// Fill Origin��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetFillMethodOrigin(this Image self, Image.Origin90 origin) {
            self.fillOrigin = (int)origin;
        }

        /// <summary>
        /// Fill Origin��ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetFillMethodOrigin(this Image self, Image.Origin360 origin) {
            self.fillOrigin = (int)origin;
        }

        /// <summary>
        /// Horizontal Fill�ɐݒ肷��g�����\�b�h
        /// </summary>
        public static void SetHorizontalFillMode(this Image self, Image.OriginHorizontal origin) {
            self.type = Image.Type.Filled;
            self.fillMethod = Image.FillMethod.Horizontal;
            self.fillOrigin = (int)origin;
        }

        /// <summary>
        /// Vertical Fill�ɐݒ肷��g�����\�b�h
        /// </summary>
        public static void SetVerticalFillMode(this Image self, Image.OriginVertical origin) {
            self.type = Image.Type.Filled;
            self.fillMethod = Image.FillMethod.Vertical;
            self.fillOrigin = (int)origin;
        }


        /// ----------------------------------------------------------------------------
        // sprite

        /// <summary>
        /// Image��Sprite�ɁA�e�N�X�`����ݒ肷��g�����\�b�h
        /// </summary>
        public static void SetTexture2D(this Image self, Texture2D tex2D) {
            if (tex2D != null) {
                self.sprite = Sprite.Create(tex2D, new Rect(0, 0, tex2D.width, tex2D.height), Vector2.zero);
            } else {
                Debug_.LogWarning("�e�N�X�`�������蓖�Ă��Ă��܂���Bsprite��null��ݒ肵�܂��B");
                self.sprite = null;
            }
        }

    }
}
