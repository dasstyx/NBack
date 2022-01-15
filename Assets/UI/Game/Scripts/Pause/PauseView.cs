using DG.Tweening;
using Pallada.Gameplay.GameState;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Game.Pause
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private float overlayAlpha = 0.5f;

        [SerializeField] private float panelAlpha = 0.3f;

        [SerializeField] private Image panel;

        [SerializeField] private Image overlay;

        [SerializeField] private CanvasGroup buttonsGroup;

        [SerializeField] private float fadeTime;

        private bool isPaused;

        [Inject] private GameProcess process;

        public void DoPause()
        {
            var fadeOut = isPaused;
            FadePauseElements(fadeOut);
            if (isPaused == true)
            {
                process.Unpause();
            }
            else
            {
                process.Stop();
            }

            isPaused = !isPaused;
        }

        private void FadePauseElements(bool fadeOut)
        {
            float groupValue = 0;
            float overlayValue = 0;
            float panelValue = 0;

            if (fadeOut == false)
            {
                groupValue = 1;
                overlayValue = overlayAlpha;
                panelValue = panelAlpha;
            }


            var overlayDoFade = overlay.DOFade(overlayValue, fadeTime);
            panel.DOFade(panelValue, fadeTime);
            var groupDoFade = buttonsGroup.DOFade(groupValue, fadeTime);
            TweenCallback finilizeGroup = () => buttonsGroup.interactable = !fadeOut;
            TweenCallback finilizeOverlay = () => overlay.raycastTarget = !fadeOut;

            if (fadeOut == true)
            {
                groupDoFade.OnComplete(finilizeGroup);
                overlayDoFade.OnComplete(finilizeOverlay);
            }
            else
            {
                groupDoFade.OnStart(finilizeGroup);
                overlayDoFade.OnStart(finilizeOverlay);
            }
        }
    }
}