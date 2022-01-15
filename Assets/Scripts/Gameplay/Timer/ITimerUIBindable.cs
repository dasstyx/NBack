using UnityEngine.UI;

namespace Pallada.Gameplay.Timer
{
    public interface ITimerUIBindable
    {
        void SubscribeToText(Text text);
    }
}