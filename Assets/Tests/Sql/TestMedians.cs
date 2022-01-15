using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pallada.DB;
using Pallada.Preset.SO;
using Pallada.Tests.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestMedians : SqlTestBase
{
    //[Test]
    public void MedianOfHits()
    {
        var hitsMedian = sqlTestHelper.ReadDb<HitsMedianFromDb, int>();
        MakeMedianResults(hitsMedian.Read, CheckHitsMedian);
    }

    //[Test]
    public void MedianOfMisses()
    {
        var missesMedian = sqlTestHelper.ReadDb<MissesMedianFromDb, int>();
        MakeMedianResults(missesMedian.Read, CheckMissesMedian);
    }

    private struct PresetVariant
    {
        public readonly int nBacks;
        public readonly int tileCounts;
        public readonly int timeLimits;

        public PresetVariant(int nBacks, int tileCounts, int timeLimits)
        {
            this.nBacks = nBacks;
            this.tileCounts = tileCounts;
            this.timeLimits = timeLimits;
        }
    }

    private void MakeMedianResults(Func<PresetData, int> dbMedian,
        Func<List<ScoreDbEntry>, int> checkMedian)
    {
        var resultsCount = 80;
        //int resultsCount = 8;

        var resultsWriter = sqlTestHelper.GetResultsWriter();
        var presetsWriter = sqlTestHelper.GetPresetsWriter();

        var presetVariants = new[]
        {
            new(2, 2, 30),
            new PresetVariant(3, 3, 60),
            new PresetVariant(6, 3, 30),
            new PresetVariant(8, 8, 80)
        };

        var presets = new List<PresetDbEntry>();
        for (var i = 0; i < presetVariants.Length; i++)
        {
            var preset = new PresetDbEntry
            {
                nBack = presetVariants[i].nBacks,
                tileCount = presetVariants[i].tileCounts,
                timeLimit = presetVariants[i].timeLimits
            };
            presets.Add(preset);
            presetsWriter.Write(preset);
        }

        var resultsSelection = new List<ScoreDbEntry>();
        var resultsForPreset = resultsCount / presets.Count;
        for (var i = 0; i < resultsCount; i++)
        {
            var presetId = Mathf.FloorToInt(i / resultsForPreset);

            var record = new ScoreDbEntry
            {
                hits = Random.Range(1, 100),
                misses = Random.Range(1, 100),
                totalHits = Random.Range(1, 100) + 50,
                presetKey = presetId + 1
            };
            if (presetId < presets.Count - 2)
            {
                resultsSelection.Add(record);
                //resultsWriter.Write(record);
            }

            resultsWriter.Write(record);
        }

        var presetToCheck = new PresetData {nback = 3, tileCount = 3, timeLimit = 30};
        var meanActual = dbMedian(presetToCheck);
        var meanExpected = checkMedian(resultsSelection);

        Assert.AreEqual(meanExpected, meanActual);
    }

    private int CheckHitsMedian(List<ScoreDbEntry> results)
    {
        return (int) results.Median(x => x.hits);
    }

    private int CheckMissesMedian(List<ScoreDbEntry> results)
    {
        return (int) results.Median(x => x.misses);
    }
}