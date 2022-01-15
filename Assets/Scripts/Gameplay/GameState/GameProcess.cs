using System;

namespace Pallada.Gameplay.GameState
{
    public class GameProcess
    {
        private Action onStop;
        private Action onTerminate;
        private Action onUnpause;

        public GameProcess()
        {
            isRunning = true;
        }

        public bool isRunning { get; private set; }
        public bool isTerminated { get; private set; }

        public void Stop()
        {
            isRunning = false;
            onStop?.Invoke();
        }

        public void Terminate()
        {
            isTerminated = true;
            onTerminate?.Invoke();
            Stop();
        }

        public void Unpause()
        {
            isRunning = true;
            onUnpause?.Invoke();
        }

        public void SubscribeOnStop(Action action)
        {
            onStop += action;
        }

        public void SubscribeOnTerminate(Action action)
        {
            onTerminate += action;
        }

        public void SubscribeUnpause(Action action)
        {
            onUnpause += action;
        }
    }
}