using System.Collections;

namespace Pallada.Gameplay.GameState.RoundEnd
{
    public interface IRoundEndEffect
    {
        IEnumerator Effect();
    }
}