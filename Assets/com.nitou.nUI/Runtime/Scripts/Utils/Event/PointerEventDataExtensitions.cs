using System.Collections.Generic;
using System.Linq;

// [�Q�l]
//  Hatena: EventSystems����󂯎�������W��RectTransform.localPosition�ɐݒ肷����@ https://appleorbit.hatenablog.com/entry/2015/10/23/000403

namespace UnityEngine.EventSystems {

    /// <summary>
    /// PointerEventData�̊g�����\�b�h�N���X
    /// </summary>
    public static class PointerEventDataExtensitions {

        /// ----------------------------------------------------------------------------
        // ���W�̎擾

        /// <summary>
        /// ���W���擾����g�����\�b�h
        /// ��Canvas��RenderMode.WorldSpace�͔�Ή�
        /// </summary>
        public static Vector2 GetScreenSpaceLocalPosition(this PointerEventData self, RectTransform parentRect) {
            var screenPosition = self.position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentRect,
                screenPosition,
                self.pressEventCamera,
                out var result
            );
            return result;
        }

        /// <summary>
        /// ���W���擾����g�����\�b�h
        /// ��Canvas��RenderMode.WorldSpace�͔�Ή�
        /// </summary>
        public static Vector2 GetScreenSpacePosition(this PointerEventData self, RectTransform parentRect) {
            var screenPosition = self.position;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                parentRect,
                screenPosition,
                self.pressEventCamera,
                out var result
            );
            return result;
        }


        /// ----------------------------------------------------------------------------
        // 

        /// <summary>
        /// �C�x���g�����n�_��DropdownArea���擾����g�����\�b�h
        /// </summary>
        public static bool TryGetRaycastArea<T>(this PointerEventData self, out T comonent) where T : Component {

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(self, results);

            comonent = results
                .Select(x => x.gameObject.GetComponent<T>())
                .FirstOrDefault(x => x != null);

            return comonent != null;
        }
    }


}