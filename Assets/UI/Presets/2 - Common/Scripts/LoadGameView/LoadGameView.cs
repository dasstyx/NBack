using System;
using Pallada.DB;
using Pallada.Gameplay.GameState;
using Pallada.Preset.PresetHolder;
using UI.Common.ClickToAction;
using UI.Presets.LoadLevel;
using UnityEngine;
using Zenject;

namespace UI.Presets.LoadGameView
{
    public abstract class LoadGameView : ButtonClickToActionBase
    {
        [Inject] private LoadGame loadGameLevel;

        [Inject] private PersistentData persistentData;

        [Inject] private DBAggregator results;

        protected abstract IPresetHolder getGameSetup { get; }
        protected override Action CallBack => Load;
        

        protected void Load()
        {
            var data = getGameSetup.Preset;
            persistentData.UpdatePreset(data);

            loadGameLevel.LoadLevel(persistentData, results);
        }
    }
}