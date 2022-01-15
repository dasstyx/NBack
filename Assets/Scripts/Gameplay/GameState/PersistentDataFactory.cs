using Pallada.DB;
using Zenject;

namespace Pallada.Gameplay.GameState
{
    public class PersistentDataFactory : IFactory<PersistentData>
    {
        private readonly DBAggregator db;

        public PersistentDataFactory(DBAggregator db)
        {
            this.db = db;
        }

        public PersistentData Create()
        {
            return new PersistentData(db);
        }
    }
}