using UnityEngine;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public interface IGridParams
    {
        Rect frame { get; }
        RectTransform RectTransform { get; }
        int TileCount { get; }
        Transform root { get; }
        GameObject TilePrefab { get; }
        float TileSpacing { get; }
    }
}