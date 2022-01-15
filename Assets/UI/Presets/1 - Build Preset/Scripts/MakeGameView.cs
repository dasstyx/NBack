using Pallada.Preset.MakePreset;
using UI.Presets.PresetBlockView;
using UnityEngine;
using Zenject;

namespace UI.Presets
{
    public class MakeGameView : MonoBehaviour
    {
        [SerializeField] private PresetBlockIntView nBackBlock;

        [SerializeField] private PresetBlockIntView tilesCountBlock;

        [SerializeField] private PresetBlockIntView timeLimitBlock;

        [SerializeField] private PresetBlockFloatView turnTimeBlock;

        [Inject] private IMakePreset makeGameSetup;

        private void Start()
        {
            nBackBlock.SubscribeValueChange(makeGameSetup.SetNBack);
            tilesCountBlock.SubscribeValueChange(makeGameSetup.SetTilesNumber);
            timeLimitBlock.SubscribeValueChange(makeGameSetup.SetTimeLimit);
            turnTimeBlock.SubscribeValueChange(makeGameSetup.SetTurnTime);
        }
    }
}