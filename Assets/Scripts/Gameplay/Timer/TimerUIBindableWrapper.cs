using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Pallada.Gameplay.Timer
{
    public class TimerUIBindableWrapper : ITimerUIBindable
    {
        private readonly ITimerExposed timer;

        public TimerUIBindableWrapper(ITimer timer)
        {
            this.timer = timer as ITimerExposed;
        }

        public void SubscribeToText(Text text)
        {
            timer.Time.Subscribe(t => text.text = FormatTime(t));
        }

        public void SubscribeToText(TextMeshProUGUI text)
        {
            timer.Time.Subscribe(t => text.text = FormatTime(t));
        }

        private string FormatTime(int time)
        {
            var mins = Mathf.FloorToInt(time / 60);
            var secs = Mathf.FloorToInt(time % 60);

            var smins = mins.ToString("00");
            var ssecs = secs.ToString("00");

            var formattedTime = mins != 0 ? $"{smins}:{ssecs}" : ssecs;
            return formattedTime;
        }
    }
}