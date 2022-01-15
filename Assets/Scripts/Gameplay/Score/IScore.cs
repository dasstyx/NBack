using UniRx;

namespace Pallada.Gameplay.Score
{
    public interface IScore
    {
        ReadOnlyReactiveProperty<int> Value { get; }

        void Plus();
    }
}