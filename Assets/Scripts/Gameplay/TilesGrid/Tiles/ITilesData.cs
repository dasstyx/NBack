using Pallada.Gameplay.TilesGrid.Entity;

namespace Pallada.Gameplay.TilesGrid.Tiles
{
    public interface ITilesData
    {
        IGridEntity[] tiles { get; }
    }
}