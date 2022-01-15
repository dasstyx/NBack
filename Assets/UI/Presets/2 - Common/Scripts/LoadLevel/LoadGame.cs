using Pallada.DB;
using Pallada.Gameplay.GameState;

namespace UI.Presets.LoadLevel
{
    public class LoadGame : LoadLevelBase
    {
        protected override string levelName => "GamePlay";

        public void LoadLevel(PersistentData data, DBAggregator db)
        {
            Load(data, db);
        }
    }
}