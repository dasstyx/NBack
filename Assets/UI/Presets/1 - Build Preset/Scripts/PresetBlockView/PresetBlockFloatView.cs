using UniRx;

namespace UI.Presets.PresetBlockView
{
    public class PresetBlockFloatView : PresetBlockView<float>
    {
        protected override void MakeReactiveSlider()
        {
            reactiveSlider = slider
                .OnValueChangedAsObservable()
                .ToReadOnlyReactiveProperty();
        }
    }
}