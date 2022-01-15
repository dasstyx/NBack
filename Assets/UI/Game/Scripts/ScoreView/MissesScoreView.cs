using Pallada.Gameplay.Score;
using Zenject;

namespace UI.Game.ScoreView
{
    public class MissesScoreView : ScoreView
    {
        [Inject] private IMissesScore injectedScore;

        protected override IScore score => injectedScore;
    }
}