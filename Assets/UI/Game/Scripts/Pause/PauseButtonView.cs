using System;
using UI.Common.ClickToAction;
using UnityEngine;

namespace UI.Game.Pause
{
    public class PauseButtonView : ButtonClickToActionBase
    {
        [SerializeField] private PauseView view;
        protected override Action CallBack => view.DoPause;
    }
}