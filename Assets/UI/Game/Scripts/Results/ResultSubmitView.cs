using System;
using Pallada.DB;
using Pallada.Gameplay.GameState.GameResult;
using Pallada.Preset.SO;
using UI.Common.ClickToAction;
using UI.Presets.LoadLevel;
using UnityEngine;
using Zenject;

namespace UI.Game.Results
{
    public class ResultSubmitView : ButtonClickToActionBase
    {
        [Inject] private DBAggregator db;

        [Inject] private PresetData preset;

        [Inject] private GameResult result;

        [Inject] private ReturnToMenu returnToMenu;
        protected override Action CallBack => Submit;

        private void Submit()
        {
            db.WriteScorePresetTuple.Write(result, preset);
            returnToMenu.Return(false);
        }
    }
}