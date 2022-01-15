using System.Collections.Generic;
using Pallada.Gameplay.TilesGrid.Entity;

namespace Pallada.Gameplay.TilesGrid.Randomizer
{
    public interface ITileRandomSubset
    {
        IEnumerable<IGridEntity> Enumerator();

        IGridEntity GetNextTile();
    }
}