using System;
using UniRx;

namespace Pallada.Gameplay.Timer
{
    public class Timer : ITimerExposed, IDisposable
    {
        private readonly CompositeDisposable disposables = new();
        private readonly ReactiveProperty<int> time;
        private readonly int timeLimit;
        private bool isWorking;

        public Timer(int limit)
        {
            timeLimit = limit;
            time = new ReactiveProperty<int>(timeLimit);
            IsOver = time.Select(x => x == 0).ToReactiveProperty();
            //IsOver = time.Select(x => x == -1).ToReactiveProperty();
        }

        public void Dispose()
        {
            disposables.Clear();
        }

        public IReadOnlyReactiveProperty<bool> IsOver { get; }
        public IReadOnlyReactiveProperty<int> Time => time;

        public void StartTimer()
        {
            if (isWorking)
            {
                return;
            }

            isWorking = true;

            var end = time
                .Where(x => !isWorking || x == 0)
                .Take(1);

            Observable.Timer(TimeSpan.FromSeconds(1))
                .RepeatSafe()
                .TakeUntil(end)
                .Subscribe(_ => time.Value--)
                .AddTo(disposables);
        }

        public void Stop()
        {
            isWorking = false;
        }

        public void SubscribeOnOver(Action action)
        {
            IsOver
                .Where(x => x == true)
                .Subscribe(_ => action?.Invoke())
                .AddTo(disposables);
        }

        public void SubscribeTimer(Action<int> action)
        {
            time.Subscribe(action)
                .AddTo(disposables);
        }
    }
}