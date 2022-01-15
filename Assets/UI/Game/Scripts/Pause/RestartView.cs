using System;
using Pallada.DB;
using Pallada.Gameplay.GameState;
using UI.Common.ClickToAction;
using UI.Presets.LoadLevel;
using UnityEngine;
using Zenject;

namespace UI.Game.Pause
{
    public class RestartView : ButtonClickToActionBase
    {
        [Inject] private PersistentData data;

        [Inject] private LoadGame loadGameLevel;

        [Inject] private DBAggregator results;
        protected override Action CallBack => DoRestart;

        private void DoRestart()
        {
            loadGameLevel.LoadLevel(data, results);
        }
    }
}