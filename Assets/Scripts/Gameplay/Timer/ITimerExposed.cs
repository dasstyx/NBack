using UniRx;

namespace Pallada.Gameplay.Timer
{
    public interface ITimerExposed : ITimer
    {
        IReadOnlyReactiveProperty<bool> IsOver { get; }
        IReadOnlyReactiveProperty<int> Time { get; }
    }
}