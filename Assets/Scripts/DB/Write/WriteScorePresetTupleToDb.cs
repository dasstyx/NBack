using Pallada.Gameplay.GameState.GameResult;
using Pallada.Preset.SO;

namespace Pallada.DB
{
    public class WriteScorePresetTupleToDb : DbAccessBase, IWriteScorePresetTupleToDb
    {
        private readonly IWritePresetToDb writePreset;
        private readonly IWriteScoreToDb writeScore;

        public WriteScorePresetTupleToDb(IRepository repository,
            IWritePresetToDb writePreset,
            IWriteScoreToDb writeScore) : base(repository)
        {
            this.writePreset = writePreset;
            this.writeScore = writeScore;
        }

        public void Write(GameResult result, PresetData preset)
        {
            var tuple = DataToDbEntry.ConvertTuple(result, preset);
            Write(tuple);
        }

        public void Write(ScorePresetTuple data)
        {
            var results = data.Score;
            var preset = data.Preset;

            var presetId = writePreset.Write(preset);
            results.presetKey = presetId;

            writeScore.Write(results);
        }
    }
}