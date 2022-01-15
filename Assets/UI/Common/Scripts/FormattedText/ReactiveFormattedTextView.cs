using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace UI.Common.FormattedText
{
    public class ReactiveFormattedTextView : MonoBehaviour
    {
        private const int trimFloat = 2;
        private bool inited;
        private string text;
        private TextMeshProUGUI textUI;

        private void Awake()
        {
            textUI = GetComponent<TextMeshProUGUI>();
            text = textUI.text;
            inited = true;
        }

        public void SubscribeToProperty<T>(IReadOnlyReactiveProperty<T> property)
        {
            property.Subscribe(x => FormatText(x));
        }

        private void FormatText<T>(T value)
        {
            if (inited == false)
            {
                return;
            }

            string stringValue;
            if (value.GetType() == typeof(float))
            {
                dynamic v = value;
                stringValue = Math.Round(v, trimFloat).ToString();
            }
            else
            {
                stringValue = value.ToString();
            }

            textUI.text = string.Format(text, stringValue);
        }
    }
}