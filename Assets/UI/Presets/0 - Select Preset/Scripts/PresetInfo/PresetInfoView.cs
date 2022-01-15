using Pallada.Preset.ChoosePreset;
using Pallada.Preset.SO;
using UnityEngine;
using Zenject;

namespace UI.Presets.PresetInfo
{
    public class PresetInfoView : MonoBehaviour
    {
        [SerializeField] private PresetInfoLine tileNumber;

        [SerializeField] private PresetInfoLine nback;

        [SerializeField] private PresetInfoLine timeLimit;

        [SerializeField] private PresetInfoLine turnTime;

        [Inject] private IChoosePresetHolder presetHolder;

        private void Start()
        {
            presetHolder.SubscribeWhenChanged(UpdatePresetInfo);
        }

        private void UpdatePresetInfo(PresetData preset)
        {
            nback.Set(preset.nback.ToString());
            turnTime.Set($"{preset.turnTime}s");
            timeLimit.Set($"{preset.timeLimit}s");

            var tileNum = preset.tileCount;
            tileNumber.Set($"{tileNum}x{tileNum}");
        }
    }
}