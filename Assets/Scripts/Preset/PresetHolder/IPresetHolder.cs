using System;
using Pallada.Preset.SO;

namespace Pallada.Preset.PresetHolder
{
    public interface IPresetHolder
    {
        PresetData Preset { get; }
        void SubscribeWhenChanged(Action<PresetData> onChange);
        void UpdatePreset(PresetData preset);
    }
}