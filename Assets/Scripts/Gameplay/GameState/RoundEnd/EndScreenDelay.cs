using System.Collections;
using UnityEngine;

namespace Pallada.Gameplay.GameState.RoundEnd
{
    public class EndScreenDelay : IRoundEndEffect
    {
        private const float delayTime = 1.5f;

        public IEnumerator Effect()
        {
            yield return new WaitForSeconds(delayTime);
        }
    }
}