using Pallada.Gameplay.Score;

namespace Pallada.Gameplay.GameState.GameResult
{
    public class GameResult
    {
        public GameResult(
            IHitsScore hits,
            IMissesScore misses,
            IMissClicksScore missClicks,
            ITotalHitsCount totalHits,
            ITotalTilesCount totalTiles,
            GameProcess gameRunning)
        {
            this.hits = hits;
            this.misses = misses;
            this.missClicks = missClicks;
            this.totalHits = totalHits;
            this.totalTiles = totalTiles;

            gameRunning.SubscribeOnTerminate(() => terminated = true);
        }

        public bool terminated { get; private set; }
        public ITotalHitsCount totalHits { get; }
        public ITotalTilesCount totalTiles { get; }
        public IHitsScore hits { get; }
        public IMissesScore misses { get; }
        public IMissClicksScore missClicks { get; }

        public int TotalHitsValue => totalHits.Value.Value;
        public int TotalTilesValue => totalTiles.Value.Value;
        public int HitsValue => hits.Value.Value;
        public int MissesValue => misses.Value.Value;
        public int MissClickValue => missClicks.Value.Value;
    }
}