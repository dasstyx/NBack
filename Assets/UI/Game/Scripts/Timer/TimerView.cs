using Pallada.Gameplay.GameState;
using Pallada.Gameplay.Timer;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Game.Timer
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerField;

        [Inject] private GameProcess process;

        [Inject] private ITimer timer;

        private void Start()
        {
            timer.StartTimer();
            process.SubscribeUnpause(timer.StartTimer);
            process.SubscribeOnStop(timer.Stop);

            new TimerUIBindableWrapper(timer)
                .SubscribeToText(timerField);
        }
    }
}