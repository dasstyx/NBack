using Pallada.Preset.SO;
using UnityEngine;

namespace Pallada.Preset.MakePreset
{
    public class MakePreset : IMakePreset
    {
        private readonly PresetData data;

        public MakePreset()
        {
            data = ScriptableObject.CreateInstance<PresetData>();
        }

        public PresetData GetData()
        {
            return data;
        }

        public void SetNBack(int nback)
        {
            data.nback = nback;
        }

        public void SetTilesNumber(int tiles)
        {
            data.tileCount = tiles;
        }

        public void SetTimeLimit(int timeLimit)
        {
            data.timeLimit = timeLimit;
        }

        public void SetTurnTime(float turnTime)
        {
            data.turnTime = turnTime;
        }
    }
}