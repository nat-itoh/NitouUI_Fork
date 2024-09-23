using UnityEngine;
using UnityEngine.UI;

namespace nitou.UI {

    public static class UIHelper {


        private static readonly Vector2Int DEFAULT_RESOLUTION = new Vector2Int(1920, 1080);


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// UI�L�����o�X������GameObject�𐶐�����
        /// </summary>
        public static Canvas CreateCanvas(string name, int sortingOrder = 0, bool needRayCaster = false) {
            var canvasObj = new GameObject(name);

            // Canvas
            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = sortingOrder;

            // Scaler
            var scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            //scaler.referenceResolution = ProjectSettingsSO.Instance.ReferenceResolution;
            scaler.referenceResolution = DEFAULT_RESOLUTION;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 1;          // ������ʃA�v����z��
            scaler.referencePixelsPerUnit = 100;

            // Graphics RayCaster
            if (needRayCaster) {
                var rayCaster = canvasObj.AddComponent<GraphicRaycaster>();
            }

            return canvas;
        }

        /// <summary>
        /// RectTransform�̎q�v�f�𐶐�����g�����\�b�h
        /// </summary>
        public static RectTransform CreateChildRect(this RectTransform parent, string name) {
            var rect = new GameObject(name).AddComponent<RectTransform>();

            // ���f�t�H���g�ł͐e�Ɠ����T�C�Y�ɂ��Ă���
            rect.transform.SetParent(parent, false);
            rect.SetSizeBasedOnEdges(0, 0, 0, 0);

            return rect;
        }
    }





}
