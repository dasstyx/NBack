using System;
using UI.Common.ClickToAction;
using UnityEngine;
using Zenject;

namespace UI.Game.GridClick
{
    public class GridClickView : ButtonClickToActionBase
    {
        [Inject] private GridClickHandler gridClickHandler;
        protected override Action CallBack => gridClickHandler.Click;
    }
}