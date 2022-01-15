using System;

namespace Pallada.Gameplay.Timer
{
    public interface ITimer
    {
        void StartTimer();
        void Stop();
        void SubscribeOnOver(Action action);

        void SubscribeTimer(Action<int> action);
    }
}