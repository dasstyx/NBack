using Pallada.Preset.MakePreset;
using Pallada.Preset.PresetHolder;
using Zenject;

namespace UI.Presets.LoadGameView
{
    public class LoadGameBuilderView : LoadGameView
    {
        [Inject] private IMakePreset makePreset;

        protected override IPresetHolder getGameSetup => new PresetHolder(makePreset.GetData());
    }
}