using TMPro;
using UnityEngine;

namespace UI.Presets.PresetInfo
{
    public class PresetInfoLine : MonoBehaviour
    {
        private TextMeshProUGUI number;

        private void Start()
        {
            number = transform.Find("Number").GetComponent<TextMeshProUGUI>();
        }

        public void Set(string text)
        {
            number.text = text;
        }
    }
}