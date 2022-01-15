using System.Collections.Generic;
using System.Linq;
using Pallada.Preset.SO;
using UnityEngine;

namespace Pallada.Preset.ChoosePreset
{
    public class ChoosePreset : IChoosePreset
    {
        private readonly IChoosePresetHolder holder;
        private readonly Dictionary<string, PresetData> stringToData;

        public ChoosePreset(
            Dictionary<string, PresetData> stringToData,
            IChoosePresetHolder holder)
        {
            this.stringToData = stringToData;
            this.holder = holder;
            this.holder.UpdatePreset(stringToData.First().Value);
        }

        public void ChooseSetup(string setupName)
        {
            if (stringToData.ContainsKey(setupName) == false)
            {
                Debug.LogWarning($"The {setupName} data object is not exist!");
                return;
            }

            holder.UpdatePreset(stringToData[setupName]);
        }
    }
}