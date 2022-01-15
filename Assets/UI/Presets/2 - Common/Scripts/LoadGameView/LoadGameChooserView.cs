using Pallada.Preset.ChoosePreset;
using Pallada.Preset.PresetHolder;
using Zenject;

namespace UI.Presets.LoadGameView
{
    public class LoadGameChooserView : LoadGameView
    {
        [Inject] private IChoosePresetHolder holder;

        protected override IPresetHolder getGameSetup => holder;
    }
}