using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace nitou {

    /// <summary>
    /// 
    /// </summary>
    public static class ReactiveProperityExtensions {


        /// ----------------------------------------------------------------------------
        #region Text

        /// <summary>
        /// 
        /// </summary>
        public static void BindToText(this IReactiveProperty<string> reactiveProperty, TMP_Text text, ICollection<IDisposable> disposables) {
            if (reactiveProperty == null) throw new ArgumentNullException(nameof(reactiveProperty));
            if (text == null) throw new ArgumentNullException(nameof(text));

            // Model -> View
            reactiveProperty.Subscribe(value => text.text = value).AddTo(disposables);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region InputField

        /// <summary>
        /// <see cref="TMP_InputField"/>との双方向バインディング．
        /// </summary>
        public static void BindToInputField(this IReactiveProperty<string> property, TMP_InputField inputField, ICollection<IDisposable> disposables) {

            // Model -> View
            property.Subscribe(value => inputField.text = value).AddTo(disposables);

            // View -> Model
            inputField.onEndEdit.AsObservable().Subscribe(value => property.Value = value).AddTo(disposables);
        }

        /// <summary>
        /// <see cref="TMP_InputField"/>との双方向バインディング．
        /// </summary>
        public static void BindToInputField(this IReactiveProperty<int> reactiveProperty, TMP_InputField inputField, ICollection<IDisposable> disposables) {
            if (reactiveProperty == null) throw new ArgumentNullException(nameof(reactiveProperty));
            if (inputField == null) throw new ArgumentNullException(nameof(inputField));
            if (disposables == null) throw new ArgumentNullException(nameof(disposables));

            // Model -> View
            reactiveProperty.Subscribe(value => inputField.text = value.ToString()).AddTo(disposables);

            // View -> Model
            inputField.onEndEdit.AsObservable()
                .Subscribe(value => {

                    if (int.TryParse(value, out int result)) {
                        reactiveProperty.Value = result;
                    } else {
                        // 数値変換に失敗した場合、モデルに反映せず、入力フィールドをリセット
                        inputField.text = reactiveProperty.Value.ToString();
                    }
                }).AddTo(disposables);
        }

        /// <summary>
        /// <see cref="TMP_InputField"/>との双方向バインディング．
        /// </summary>
        public static void BindToInputFieldFloat(this IReactiveProperty<float> reactiveProperty, TMP_InputField inputField, ICollection<IDisposable> disposables) {
            if (reactiveProperty == null) throw new ArgumentNullException(nameof(reactiveProperty));
            if (inputField == null) throw new ArgumentNullException(nameof(inputField));
            if (disposables == null) throw new ArgumentNullException(nameof(disposables));

            // Model -> View
            reactiveProperty.Subscribe(value => inputField.text = value.ToString("G")).AddTo(disposables);  // "G" は汎用的な数値フォーマット

            // View -> Model
            inputField.onEndEdit.AsObservable()
                .Subscribe(value => {
                    if (float.TryParse(value, out float result)) {
                        reactiveProperty.Value = result;
                    } else {
                        // 数値変換に失敗した場合、モデルに反映せず、入力フィールドをリセット
                        inputField.text = reactiveProperty.Value.ToString("G");
                    }
                }).AddTo(disposables);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Slider

        /// <summary>
        /// 
        /// </summary>
        public static void BindToSlider(this IReactiveProperty<float> property, Slider slider, ICollection<IDisposable> disposables) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (slider == null) throw new ArgumentNullException(nameof(slider));

            // Model -> View
            property.Subscribe(value => slider.value = value).AddTo(disposables);

            // View -> Model
            slider.onValueChanged.AsObservable().Subscribe(value => property.Value = value).AddTo(disposables);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Toggle

        /// <summary>
        /// 
        /// </summary>
        public static void BindToToggle(this IReactiveProperty<bool> property, Toggle toggle, ICollection<IDisposable> disposables) {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (toggle == null) throw new ArgumentNullException(nameof(toggle));

            // Model -> View
            property.Subscribe(value => toggle.isOn = value).AddTo(disposables);

            // View -> Model
            toggle.onValueChanged.AsObservable().Subscribe(value => property.Value = value).AddTo(disposables);
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Dropdown

        /// <summary>
        /// 
        /// </summary>
        public static void BindToDropdown(this IReactiveProperty<int> reactiveProperty, TMP_Dropdown dropdown, ICollection<IDisposable> disposables) {
            if (reactiveProperty == null) throw new ArgumentNullException(nameof(reactiveProperty));
            if (dropdown == null) throw new ArgumentNullException(nameof(dropdown));

            // Model -> View
            reactiveProperty.Subscribe(value => dropdown.value = value).AddTo(disposables);

            // View -> Model
            dropdown.onValueChanged.AsObservable().Subscribe(value => reactiveProperty.Value = value).AddTo(disposables);
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Image

        /// <summary>
        /// 
        /// </summary>
        public static void BindToImageFillAmount(this IReactiveProperty<float> reactiveProperty, Image image, ICollection<IDisposable> disposables) {
            if (reactiveProperty == null) throw new ArgumentNullException(nameof(reactiveProperty));
            if (image == null) throw new ArgumentNullException(nameof(image));

            // Model -> View
            reactiveProperty.Subscribe(value => image.fillAmount = value).AddTo(disposables);
        }
        #endregion

    }









}
