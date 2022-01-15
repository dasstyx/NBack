using Pallada.Gameplay.GameState.GameResult;
using Pallada.Preset.SO;

namespace Pallada.DB
{
    public interface IWriteScorePresetTupleToDb : IDbWrite<ScorePresetTuple>
    {
        void Write(GameResult result, PresetData preset);
        void Write(ScorePresetTuple data);
    }
}