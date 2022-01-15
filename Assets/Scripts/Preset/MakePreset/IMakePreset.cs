using Pallada.Preset.SO;

namespace Pallada.Preset.MakePreset
{
    public interface IMakePreset
    {
        PresetData GetData();
        void SetNBack(int nback);
        void SetTilesNumber(int tiles);
        void SetTimeLimit(int tiles);
        void SetTurnTime(float turnTime);
    }
}