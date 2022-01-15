using System;
using UnityEngine;

namespace UI.Common.ClickToAction
{
    public abstract class ClickToActionBase : MonoBehaviour
    {
        protected abstract Action CallBack { get; }

        protected virtual void Start()
        {
            if (CallBack == null)
            {
                Debug.LogError($"Callback action of the '{name}' is missing");
                return;
            }
            OnClick();
        }

        protected abstract void OnClick();
    }
}