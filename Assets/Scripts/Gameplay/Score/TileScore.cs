using UniRx;

namespace Pallada.Gameplay.Score
{
    public class TileScore : IScore
    {
        private readonly ReactiveProperty<int> _value;

        protected TileScore()
        {
            _value = new ReactiveProperty<int>();
        }

        public ReadOnlyReactiveProperty<int> Value => _value.ToReadOnlyReactiveProperty();

        public void Plus()
        {
            _value.Value++;
        }
    }
}