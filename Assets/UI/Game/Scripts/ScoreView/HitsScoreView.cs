using Pallada.Gameplay.Score;
using Zenject;

namespace UI.Game.ScoreView
{
    public class HitsScoreView : ScoreView
    {
        [Inject] private IHitsScore injectedScore;

        protected override IScore score => injectedScore;
    }
}