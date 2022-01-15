using System;
using UI.Common.ClickToAction;
using UnityEngine;
using Zenject;

namespace UI.Presets.LoadLevel
{
    public class ReturnToMenuView : ButtonClickToActionBase
    {
        [SerializeField] private bool terminateProcess;

        [Inject] private ReturnToMenu returnToMenu;
        protected override Action CallBack => Return;

        private void Return()
        {
            returnToMenu.Return(terminateProcess);
        }
    }
}