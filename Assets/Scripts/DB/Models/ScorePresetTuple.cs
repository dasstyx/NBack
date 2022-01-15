namespace Pallada.DB
{
    public class ScorePresetTuple
    {
        public ScorePresetTuple(ScoreDbEntry score, PresetDbEntry preset)
        {
            Score = score;
            Preset = preset;
        }

        public ScoreDbEntry Score { get; }
        public PresetDbEntry Preset { get; }
    }
}