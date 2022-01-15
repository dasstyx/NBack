using System.Collections;
using DG.Tweening;
using Pallada.Preset.SO;
using UnityEngine.UI;
using Zenject;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public sealed class ImageGridEntity : GridEntityBase
    {
        private Image highlight;
        private float highlightAlpha;

        [Inject] private PresetData preset;

        private float fadeTime => preset.turnTime / 2;

        // TODO: Don't use this mysterious IEnumerator way any futher
        protected override IEnumerator CompleteInit()
        {
            highlight = transform.GetChild(0).GetComponent<Image>();
            highlightAlpha = highlight.color.a;
            yield return TweenUnHighlight();
        }

        protected override IEnumerator TweenHighlight()
        {
            yield return highlight.DOFade(highlightAlpha, fadeTime).WaitForCompletion();
        }

        protected override IEnumerator TweenUnHighlight()
        {
            yield return highlight.DOFade(0, fadeTime).WaitForCompletion();
        }
    }
}