namespace Pallada.DB
{
    public class ScoreDbEntry
    {
        public int id { get; set; }
        public int hits { get; set; }
        public int misses { get; set; }
        public int missClicks { get; set; }
        public int totalHits { get; set; }
        public int totalTiles { get; set; }
        public int presetKey { get; set; }
    }
}