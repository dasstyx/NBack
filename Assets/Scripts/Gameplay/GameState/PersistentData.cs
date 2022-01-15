using Pallada.DB;
using Pallada.Preset.SO;

namespace Pallada.Gameplay.GameState
{
    public class PersistentData
    {
        public PersistentData(DBAggregator db)
        {
            this.db = db;
        }

        public PresetData Preset { get; private set; }
        public DBAggregator db { get; }

        public void UpdatePreset(PresetData preset)
        {
            Preset = preset;
        }
    }
}