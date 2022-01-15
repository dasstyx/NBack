using NSubstitute;
using NUnit.Framework;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.MakeGrid;
using Pallada.Gameplay.TilesGrid.Tiles;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[TestFixture]
public class MakeGridTest : ZenjectUnitTestFixture
{
    [Test]
    public void MatchCount()
    {
        MakeGridParams();
        var gridParams = Container.Resolve<IGridParams>();

        var expectedCount = (int) Mathf.Pow(gridParams.TileCount, 2);
        var tiles = MakeTiles().tiles;

        Assert.AreEqual(expectedCount, tiles.Length);
    }

    //[Test]
    //public void MatchSize()
    //{
    //    var gridParams = MakeGridParams();
    //    IGridEntity[] tiles = MakeTiles(gridParams, new Vector2(220, 220));

    //}

    private TilesData MakeTiles()
    {
        Container.BindFactory<IGridEntity, GridEntityFactory>()
            .FromFactory<GridEntityPrefabFactory>();
        Container.Bind<TilesData>().FromFactory<MakeGridFactory>().AsSingle();
        var tilesData = Container.Resolve<TilesData>();
        return tilesData;
    }

    private void MakeGridParams()
    {
        var size = 200;
        var count = 3;
        var rectTransform = GetRectTransform(Vector2.zero, new Vector2(size, size));
        var gridParams = Substitute.For<IGridParams>();
        gridParams.root.Returns(rectTransform.transform);
        gridParams.frame.Returns(rectTransform.rect);
        gridParams.TileCount.Returns(count);
        gridParams.TileSpacing.Returns(1);

        var tilePrefab = new GameObject("tile", typeof(NullGridEntity));
        gridParams.TilePrefab.Returns(tilePrefab);

        Container.Bind<IGridParams>().FromInstance(gridParams).AsSingle();
    }

    private RectTransform GetRectTransform(Vector2 pos, Vector2 size)
    {
        var rectGo = new GameObject(
            "rect",
            typeof(RectTransform),
            typeof(GridLayoutGroup));
        var rectTransform = rectGo.GetComponent<RectTransform>();
        var rect = rectTransform.rect;
        rect.position = pos;
        rect.size = size;
        return rectTransform;
    }
}