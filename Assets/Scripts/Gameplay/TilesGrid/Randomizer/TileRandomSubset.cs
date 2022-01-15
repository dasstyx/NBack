using System;
using System.Collections.Generic;
using System.Linq;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Tiles;

namespace Pallada.Gameplay.TilesGrid.Randomizer
{
    public class TileRandomSubset : ITileRandomSubset
    {
        private readonly Random rnd;
        private readonly int subsetCount;
        private readonly Queue<IGridEntity> tileQueue;

        public TileRandomSubset(ITilesData data)
        {
            rnd = new Random();
            subsetCount = RandomSubsetCount(data);
            var subset = DataSubset(data);

            tileQueue = new Queue<IGridEntity>(subset.tiles);
        }

        public IEnumerable<IGridEntity> Enumerator()
        {
            while (tileQueue.Count > 0)
            {
                yield return GetNextTile();
            }
        }

        public IGridEntity GetNextTile()
        {
            return tileQueue.Dequeue();
        }

        private TilesData DataSubset(ITilesData data)
        {
            var tiles = data.tiles;
            tiles = tiles.OrderBy(x => rnd.Next()).ToArray();
            var segment = new ArraySegment<IGridEntity>(tiles, 0, subsetCount);

            return new TilesData(segment.ToArray());
        }

        private int RandomSubsetCount(ITilesData data)
        {
            var min = 3;
            var max = 5;
            return rnd.Next(min, max);
        }
    }
}