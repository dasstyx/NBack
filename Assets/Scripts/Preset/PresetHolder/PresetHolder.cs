using System;
using Pallada.Preset.SO;
using UniRx;

namespace Pallada.Preset.PresetHolder
{
    public class PresetHolder : IPresetHolder
    {
        private Action<PresetData> onChange;

        public PresetHolder(PresetData preset) : this()
        {
            UpdatePreset(preset);
        }

        public PresetHolder()
        {
        }

        public PresetData Preset { get; private set; }

        public void UpdatePreset(PresetData preset)
        {
            Preset = preset;
            Preset.ObserveEveryValueChanged(x => x.nback).Subscribe(_ => UpdatePreset());
            Preset.ObserveEveryValueChanged(x => x.tileCount).Subscribe(_ => UpdatePreset());
            Preset.ObserveEveryValueChanged(x => x.timeLimit).Subscribe(_ => UpdatePreset());
            Preset.ObserveEveryValueChanged(x => x.turnTime).Subscribe(_ => UpdatePreset());

            onChange?.Invoke(preset);
        }

        public void SubscribeWhenChanged(Action<PresetData> onChange)
        {
            this.onChange += onChange;
        }

        private void UpdatePreset()
        {
            onChange?.Invoke(Preset);
        }
    }
}