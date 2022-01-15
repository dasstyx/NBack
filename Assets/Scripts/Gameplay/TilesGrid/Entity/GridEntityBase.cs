using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public abstract class GridEntityBase : MonoBehaviour, IGridEntity
    {
        protected Action<int> pressed;

        [SerializeField] public int id { get; private set; }

        public virtual IEnumerator HighlightTile()
        {
            yield return StartHighlighting();
        }

        public void Init(int id, Action<int> pressed = null)
        {
            this.id = id;
            this.pressed = pressed;
            CompleteInit().ToObservable().Subscribe();
        }

        public void Press()
        {
            pressed?.Invoke(id);
        }

        protected abstract IEnumerator CompleteInit();

        protected IEnumerator StartHighlighting()
        {
            yield return TweenHighlight();
            yield return TweenUnHighlight();
        }

        protected abstract IEnumerator TweenHighlight();

        protected abstract IEnumerator TweenUnHighlight();
    }
}