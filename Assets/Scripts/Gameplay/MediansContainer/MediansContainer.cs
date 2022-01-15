using Pallada.DB;
using Pallada.Preset.SO;
using Zenject;

namespace Pallada.Gameplay.MediansContainer
{
    public class MediansContainer
    {
        private DBAggregator db;

        public MediansContainer(DBAggregator db, PresetData preset)
        {
            this.db = db;

            medianHits = db.ReadHitsMedian.Read(preset);
            medianMisses = db.ReadMissesMedian.Read(preset);
        }

        public int medianHits { get; }
        public int medianMisses { get; }
    }
}