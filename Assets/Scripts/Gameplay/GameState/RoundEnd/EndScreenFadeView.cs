using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using RoundEnd_1 = RoundEnd;

namespace Pallada.Gameplay.GameState.RoundEnd
{
    public class EndScreenFadeView : MonoBehaviour, IRoundEndEffect
    {
        [SerializeField] private Image overlay;

        [Inject] private RoundEnd_1 roundEnd;

        public IEnumerator Effect()
        {
            yield return overlay.DOFade(1, 1).WaitForCompletion();
        }
    }
}