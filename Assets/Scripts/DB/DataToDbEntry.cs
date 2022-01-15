using Pallada.Gameplay.GameState.GameResult;
using Pallada.Preset.SO;

namespace Pallada.DB
{
    public static class DataToDbEntry
    {
        public static ScorePresetTuple ConvertTuple(GameResult result, PresetData preset)
        {
            var resultEntry = ConvertResult(result);
            var presetEntry = ConvertPreset(preset);

            return new ScorePresetTuple(resultEntry, presetEntry);
        }


        public static ScoreDbEntry ConvertResult(GameResult result)
        {
            return new ScoreDbEntry
            {
                hits = result.HitsValue,
                misses = result.MissesValue,
                missClicks = result.MissClickValue,
                totalHits = result.TotalHitsValue,
                totalTiles = result.TotalTilesValue,
                presetKey = 0
            };
        }

        public static PresetDbEntry ConvertPreset(PresetData preset)
        {
            return new PresetDbEntry
            {
                nBack = preset.nback,
                tileCount = preset.tileCount,
                timeLimit = preset.timeLimit,
                turnTime = preset.turnTime
            };
        }
    }
}