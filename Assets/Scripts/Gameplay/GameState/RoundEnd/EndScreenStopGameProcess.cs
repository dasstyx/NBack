using System.Collections;
using Zenject;

namespace Pallada.Gameplay.GameState.RoundEnd
{
    public class EndScreenStopGameProcess : IRoundEndEffect
    {
        [Inject] private GameProcess gameProcess;

        public IEnumerator Effect()
        {
            gameProcess.Stop();
            yield return null;
        }
    }
}