using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Tiles;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pallada.Gameplay.TilesGrid.MakeGrid
{
    public class MakeGridFactory : IFactory<TilesData>
    {
        private readonly IGridParams param;
        private readonly GridEntityFactory tileFactory;

        public MakeGridFactory(IGridParams param, GridEntityFactory tileFactory)
        {
            this.param = param;
            this.tileFactory = tileFactory;
        }

        public TilesData Create()
        {
            return new TilesData(Make());
        }

        private IGridEntity[] Make()
        {
            var frame = param.frame;
            var frameSize = new Vector2(frame.width, frame.height);
            var tileSizeX = frameSize.x / param.TileCount;
            var count = param.TileCount * param.TileCount;

            var gridLayout = param.root.GetComponent<GridLayoutGroup>();
            gridLayout.constraintCount = param.TileCount;
            var spacing = new Vector2(param.TileSpacing, param.TileSpacing);
            gridLayout.spacing = spacing;

            var padding = new Vector2(gridLayout.padding.top, gridLayout.padding.bottom);
            padding /= param.TileCount - 1;

            tileSizeX = tileSizeX - spacing.x - padding.x;
            var tileSize = new Vector2(tileSizeX, tileSizeX);
            gridLayout.cellSize = tileSize;

            var entites = new IGridEntity[count];
            for (var i = 0; i < count; i++)
            {
                MakeTile(entites, i);
            }

            return entites;
        }

        private void MakeTile(IGridEntity[] entites, int index)
        {
            var gridEntity = tileFactory.Create();
            var root = param.root;
            gridEntity.transform.SetParent(param.root);
            // TODO: resolve the kludge
            gridEntity.transform.SetPositionAndRotation(root.position, root.rotation);
            gridEntity.transform.localScale = Vector3.one;
            gridEntity.Init(index);
            entites[index] = gridEntity;
        }
    }
}