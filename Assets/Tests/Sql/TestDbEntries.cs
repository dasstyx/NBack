using System.Linq;
using Dapper;
using NUnit.Framework;
using Pallada.DB;
using UnityEngine;

public class TestDbEntries : SqlTestBase
{
    // [Test]
    public void RecordResults()
    {
        var collection = sqlTestHelper.GetResultsWriter();
        var record = GetRandomRecord();
        collection.Write(record);

        ScoreDbEntry latestRecord;
        using (var cnn = sqlTestHelper.Repo.DbConnection())
        {
            latestRecord = cnn.Query<ScoreDbEntry>(
                @"SELECT * FROM results WHERE id = (SELECT MAX(id) FROM results);"
            ).First();
        }

        Assert.AreEqual(record.hits, latestRecord.hits);
        Assert.AreEqual(record.misses, latestRecord.misses);
        Assert.AreEqual(record.totalHits, latestRecord.totalHits);
        Assert.AreEqual(record.presetKey, latestRecord.presetKey);
    }

    [Test]
    public void RecordPreset()
    {
        var collection = sqlTestHelper.GetPresetsWriter();
        var preset = GetRandomPreset();
        collection.Write(preset);

        PresetDbEntry latestPreset;
        using (var cnn = sqlTestHelper.Repo.DbConnection())
        {
            latestPreset = cnn.Query<PresetDbEntry>(
                @"SELECT * FROM preset WHERE id = (SELECT MAX(id) FROM preset);"
            ).First();
        }

        Assert.AreEqual(preset.nBack, latestPreset.nBack);
        Assert.AreEqual(preset.tileCount, latestPreset.tileCount);
        Assert.AreEqual(preset.timeLimit, latestPreset.timeLimit);
        Assert.AreEqual(preset.turnTime, latestPreset.turnTime);
    }

    private PresetDbEntry GetRandomPreset()
    {
        var nBack = Random.Range(2, 8);
        var tileCount = Random.Range(1, 10);
        var timeLimit = Random.Range(10, 120);
        var turnTime = Random.Range(0f, 1f);

        return new PresetDbEntry
        {
            nBack = nBack,
            tileCount = tileCount,
            turnTime = turnTime,
            timeLimit = timeLimit
        };
    }

    private ScoreDbEntry GetRandomRecord()
    {
        var hits = Random.Range(0, 100);
        var misses = Random.Range(0, 100);
        var totalHits = Random.Range(hits, hits + 100);

        return new ScoreDbEntry
        {
            hits = hits,
            misses = misses,
            totalHits = totalHits,
            presetKey = 1
        };
    }
}