using System.Collections;
using ScreenMgr;
using Zenject;

namespace Pallada.Gameplay.GameState.RoundEnd
{
    public class EndScreenResultsScreen : IRoundEndEffect
    {
        [Inject] private ScreenManager screenManager;

        public IEnumerator Effect()
        {
            screenManager.Show("Result");
            yield return null;
        }
    }
}