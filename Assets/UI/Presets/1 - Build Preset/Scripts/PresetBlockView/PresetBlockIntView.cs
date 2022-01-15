using UniRx;

namespace UI.Presets.PresetBlockView
{
    public class PresetBlockIntView : PresetBlockView<int>
    {
        protected override void MakeReactiveSlider()
        {
            reactiveSlider = slider
                .OnValueChangedAsObservable()
                .Select(x => (int) x)
                .ToReadOnlyReactiveProperty();
        }
    }
}