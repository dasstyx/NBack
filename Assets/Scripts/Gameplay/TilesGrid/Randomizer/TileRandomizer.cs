using System.Collections.Generic;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Tiles;
using Pallada.Settings;
using UnityEngine;

namespace Pallada.Gameplay.TilesGrid.Randomizer
{
    public class TileRandomizer : ITileRandomizer
    {
        private readonly ITilesData data;
        private readonly GameChancesSettings gameChances;
        private readonly ChooseRightTile rightTile;

        public TileRandomizer(
            TilesData tiles,
            GameChancesSettings gameChances,
            ChooseRightTile rightTile)
        {
            data = tiles;
            this.gameChances = gameChances;
            this.rightTile = rightTile;
        }

        public IEnumerable<IGridEntity> GetRandomTile()
        {
            while (true)
            {
                var subset = new TileRandomSubset(data);
                foreach (var subsetTile in subset.Enumerator())
                {
                    IGridEntity tile;
                    if (Random.value > gameChances.RepeatChance)
                    {
                        tile = subsetTile;
                    }
                    else
                    {
                        tile = rightTile.GetTile();
                    }

                    if (tile.GetType() != typeof(NullGridEntity))
                    {
                        yield return tile;
                    }
                }
            }
        }
    }
}