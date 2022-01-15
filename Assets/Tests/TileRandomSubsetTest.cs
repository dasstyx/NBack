using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Randomizer;
using Pallada.Gameplay.TilesGrid.Tiles;
using Zenject;

[TestFixture]
public class TileRandomSubsetTest : ZenjectUnitTestFixture
{
    [Test]
    public void Enumerator_ExpectedBehaviour()
    {
        var tilesCount = 22;
        Func<int, bool> TilesCountIsLessThan = i => i < tilesCount / 3;

        var subset = MakeTilesRandomSubset(tilesCount);

        var actualCount = 0;
        var tilesHash = new HashSet<IGridEntity>();
        foreach (var tile in subset.Enumerator())
        {
            if (tilesHash.Contains(tile))
            {
                Assert.Fail("The subset contains dublicates");
                return;
            }

            tilesHash.Add(tile);
            actualCount++;
        }

        var moreThanZero = actualCount > 0;
        Assert.True(moreThanZero, "Subset count equals zero");
        Assert.True(TilesCountIsLessThan(actualCount),
            "Subset count is more than expected");
    }

    private TileRandomSubset MakeTilesRandomSubset(int count)
    {
        var tiles = Enumerable.Range(1, count)
            .Select(id => GetTile(id))
            .ToArray();
        var data = Substitute.For<ITilesData>();
        data.tiles.Returns(tiles);

        return new TileRandomSubset(data);
    }

    private IGridEntity GetTile(int? id = null)
    {
        var entity = Substitute.For<IGridEntity>();
        if (id != null)
        {
            entity.id.Returns(id.Value);
        }

        return entity;
    }
}