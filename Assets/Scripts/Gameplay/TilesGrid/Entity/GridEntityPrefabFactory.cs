using Zenject;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public class GridEntityFactory : PlaceholderFactory<IGridEntity>
    {
    }

    public class GridEntityPrefabFactory : IFactory<IGridEntity>
    {
        private readonly DiContainer container;
        private readonly IGridParams param;

        public GridEntityPrefabFactory(DiContainer container, IGridParams param)
        {
            this.container = container;
            this.param = param;
        }

        public IGridEntity Create()
        {
            var prefab = param.TilePrefab;
            return container.InstantiatePrefabForComponent<IGridEntity>(prefab);
        }
    }
}