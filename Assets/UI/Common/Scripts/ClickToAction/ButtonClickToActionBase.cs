using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common.ClickToAction
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonClickToActionBase : ClickToActionBase
    {
        protected override void OnClick()
        {
            var button = GetComponent<Button>();
            button.OnClickAsObservable().Subscribe(_ => CallBack.Invoke());
        }
    }
}