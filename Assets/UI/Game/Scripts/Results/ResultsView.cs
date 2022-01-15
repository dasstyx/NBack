using System.Collections.Generic;
using Pallada.Gameplay.GameState;
using Pallada.Gameplay.GameState.GameResult;
using Pallada.Gameplay.MediansContainer;
using UnityEngine;
using Zenject;

namespace UI.Game.Results
{
    public class ResultsView : MonoBehaviour
    {
        [SerializeField] private RectTransform linesCollection;

        [Inject] private ResultLineFactory factory;

        [Inject] private MediansContainer medians;

        [Inject] private PersistentData persistentData;

        [Inject] private GameResult result;

        private void OnEnable()
        {
            FillLinesCollection();
        }

        private void FillLinesCollection()
        {
            var hitsDiff = result.HitsValue - medians.medianHits;
            var missesDiff = result.MissesValue - medians.medianMisses;
            var totalSeconds = $"{persistentData.Preset.timeLimit.ToString()}s";
            var lines = new List<RectTransform>
            {
                //MakeLine("Hits", GetPercent(result.HitsValue, result.TotalHitsValue), 0),
                MakeLine("Hits", result.HitsValue.ToString(), hitsDiff, false),
                MakeLine("Misses", result.MissesValue.ToString(), missesDiff, true),
                MakeLine("Miss clicks", result.MissClickValue.ToString()),
                MakeLine("Correct highlights", result.TotalHitsValue.ToString()),
                MakeLine("All highlights", result.TotalTilesValue.ToString()),
                MakeLine("Time limit", totalSeconds)
            };

            foreach (var line in lines)
            {
                line.transform.SetParent(linesCollection);
            }
        }

        private string GetPercent(float value, float from)
        {
            return $"{Mathf.RoundToInt(value / from * 100)}%";
        }

        private RectTransform MakeLine(string title,
            string value)
        {
            var line = new ResultLine(title, value);
            return factory.MakeResultLine(line);
        }

        private RectTransform MakeLine(string title,
            string value,
            int derivation,
            bool derivationFlavour)
        {
            var line = new ResultLine(title, value, derivation, derivationFlavour);
            return factory.MakeResultLine(line);
        }
    }
}