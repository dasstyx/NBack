namespace Pallada.DB
{
    public class DBAggregator
    {
        public readonly IHitsMedianFromDb ReadHitsMedian;
        public readonly IMissesMedianFromDb ReadMissesMedian;
        public readonly IWriteScorePresetTupleToDb WriteScorePresetTuple;

        public DBAggregator(IWriteScorePresetTupleToDb writeScorePresetTuple,
            IHitsMedianFromDb readHitsMedian,
            IMissesMedianFromDb readMissesMedian)
        {
            WriteScorePresetTuple = writeScorePresetTuple;
            ReadHitsMedian = readHitsMedian;
            ReadMissesMedian = readMissesMedian;
        }
    }
}