using Pallada.Gameplay.TilesGrid.Entity;

namespace Pallada.Gameplay.TilesGrid.Tiles
{
    public struct TilesData : ITilesData
    {
        public TilesData(IGridEntity[] tiles)
        {
            this.tiles = tiles;
        }

        public readonly IGridEntity[] tiles { get; }
    }
}