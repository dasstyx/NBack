using System;
using UI.Common.FormattedText;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presets.PresetBlockView
{
    public abstract class PresetBlockView<T> : MonoBehaviour
    {
        [SerializeField] private ReactiveFormattedTextView text;

        [SerializeField] protected Slider slider;

        private Action<T> onValueChange;

        protected IReadOnlyReactiveProperty<T> reactiveSlider;

        private void Start()
        {
            MakeReactiveSlider();

            text.SubscribeToProperty(reactiveSlider);
            reactiveSlider.Subscribe(x => onValueChange?.Invoke(x));
        }

        public void SubscribeValueChange(Action<T> action)
        {
            onValueChange += action;
        }

        protected abstract void MakeReactiveSlider();
    }
}