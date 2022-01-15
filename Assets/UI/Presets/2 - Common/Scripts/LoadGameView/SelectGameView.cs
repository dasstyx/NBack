using System;
using Pallada.Preset.ChoosePreset;
using UI.Common.ClickToAction;
using UnityEngine;
using Zenject;

namespace UI.Presets.LoadGameView
{
    public class SelectGameView : ReactiveToggleButton
    {
        [SerializeField] private string presetName;
        [Inject] protected IChoosePreset ChoosePreset { get; }
        protected override Action CallBack => SelectPreset;

        private void SelectPreset()
        {
            ChoosePreset.ChooseSetup(presetName);
        }
    }
}