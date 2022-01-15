using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common.ClickToAction
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ReactiveToggleButton : ClickToActionBase
    {
        protected override void OnClick()
        {
            var toggle = GetComponent<Toggle>();
            toggle.OnValueChangedAsObservable()
                .Where(x => x == true)
                .Subscribe(_ => CallBack.Invoke());
        }
    }
}